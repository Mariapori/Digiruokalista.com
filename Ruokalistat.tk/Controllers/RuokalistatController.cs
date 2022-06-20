using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using Ruokalistat.tk.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator;
using PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Ruokalistat.tk.Controllers
{

    [Authorize]
    public class RuokalistatController : Microsoft.AspNetCore.Mvc.Controller
    {
        private tietokantaContext db;
        private int tuloksienMaara = 15;


        public RuokalistatController(tietokantaContext db) 
        {
            this.db = db;
        }


        [AllowAnonymous]
        public IActionResult Index(int? sivu = 1, string? hakusana = "", string? kaupunki = "")
        {
            ViewBag.kaupungit = Kaupungit(kaupunki);
            var ravintolat = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).OrderBy(o => o.Nimi).Where(o => o.Ruokalista.piilotettu == false);
            if (User.Identity.IsAuthenticated)
            {
                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ravintolat = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).OrderBy(o => o.Nimi).Where(o => o.Owner == user || User.IsInRole("Admin"));
            }

            if (!string.IsNullOrEmpty(hakusana))
            {
                ravintolat = ravintolat.Where(o => o.Nimi.ToLower().Contains(hakusana));
            }

            if (!string.IsNullOrEmpty(kaupunki))
            {
                ravintolat = ravintolat.Where(o => o.Kaupunki.ToLower() == kaupunki);
                ViewBag.kaupunki = kaupunki;
            }

            return View(ravintolat.ToPagedList<Yritys>(sivu.GetValueOrDefault(), tuloksienMaara));
        }

        public IActionResult Uusi()
        {
            Yritys yritys = new Yritys();
            return View(yritys);
        }

        public List<SelectListItem> Kaupungit(string kaupunki)
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            foreach (var item in db.Yritys.Select(o => o.Kaupunki).Distinct().OrderBy(o => o).ToList())
            {
                if (item.ToLower() == kaupunki)
                {
                    lista.Add(new SelectListItem { Text = item, Value = item, Selected = true });
                }
                else
                {
                    lista.Add(new SelectListItem { Text = item, Value = item, Selected = false });
                }
            }
            return lista;
        }

        [HttpPost]
        public IActionResult Uusi(Yritys model)
        {
            try
            {
                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                model.Ruokalista = new Ruokalista();
                model.Owner = user;
                db.Yritys.Add(model);
                db.SaveChanges();
            }
            catch
            {
            }

            return RedirectToAction("Index");
        }

        public IActionResult Poista(int ID)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ravintola = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).First(o => o.ID == ID && (o.Owner == user || User.IsInRole("Admin")));
            db.Yritys.Remove(ravintola);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Muokkaa(int ID)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ravintola = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).First(o => o.ID == ID && (o.Owner == user || User.IsInRole("Admin")));
            return View(ravintola);
        }

        [HttpPost]
        public IActionResult Muokkaa(Yritys model)
        {
            try
            {
                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var vanha = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).First(o => o.ID == model.ID && (o.Owner == user || User.IsInRole("Admin")));

                vanha.Kaupunki = model.Kaupunki;
                vanha.Nimi = model.Nimi;
                vanha.Osoite = model.Osoite;
                vanha.Postinumero = model.Postinumero;
                vanha.Puhelin = model.Puhelin;
                vanha.yTunnus = model.yTunnus;
                vanha.Ruokalista.piilotettu = model.Ruokalista.piilotettu;


                db.SaveChanges();
            }
            catch
            {
            }
            return RedirectToAction("Muokkaa", new { ID = model.ID });
        }

        [HttpPost]
        public IActionResult UusiKat(int YritysID, string Kuvaus, string Nimi2)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var yritys = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).First(o => o.ID == YritysID && (o.Owner == user || User.IsInRole("Admin")));
            if (yritys.Ruokalista == null)
            {
                yritys.Ruokalista = new Ruokalista();
                yritys.Ruokalista.Kategoriat = new List<Kategoria>();
            }
            yritys.Ruokalista.Kategoriat.Add(new Kategoria { Kuvaus = Kuvaus, Nimi = Nimi2, Ruuat = new List<Ruoka>() });
            yritys.Ruokalista.viimeksiPaivitetty = DateTime.Now;
            db.SaveChanges();

            return View("Muokkaa", yritys);
        }
        public IActionResult PoistaKat(int ID, int KatID)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var yritys = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).First(o => o.ID == ID && (o.Owner == user || User.IsInRole("Admin")));
            var kategoria = yritys.Ruokalista.Kategoriat.First(o => o.ID == KatID);
            yritys.Ruokalista.viimeksiPaivitetty = DateTime.Now;
            db.Remove(kategoria);
            db.SaveChanges();

            return View("Muokkaa", yritys);
        }

        public IActionResult MuokkaaKat(int ID, int KatID)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var yritys = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).First(o => o.ID == ID && (o.Owner == user || User.IsInRole("Admin")));
            var kategoria = yritys.Ruokalista.Kategoriat.First(o => o.ID == KatID);

            ViewBag.yritysID = yritys.ID;
            ViewBag.katID = kategoria.ID;

            return View("MuokkaaKat", kategoria);
        }
        [HttpPost]
        public IActionResult MuokkaaKat(int katID, int YritysID, Kategoria model)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var yritys = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).First(o => o.ID == YritysID && (o.Owner == user || User.IsInRole("Admin")));
            var kategoria = yritys.Ruokalista.Kategoriat.First(o => o.ID == katID);

            kategoria.Nimi = model.Nimi;
            kategoria.Kuvaus = model.Kuvaus;

            yritys.Ruokalista.viimeksiPaivitetty = DateTime.Now;
            db.SaveChanges();

            return RedirectToAction("Muokkaa", yritys);
        }
        [HttpPost]
        public IActionResult UusiRuoka(int Kategoria, int YritysID, string Nimi3, string Kuvaus2, bool Vegan, decimal Hinta, bool Annos, int annosNro)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var yritys = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).First(o => o.ID == YritysID && (o.Owner == user || User.IsInRole("Admin")));
            var kategoria = yritys.Ruokalista.Kategoriat.First(o => o.ID == Kategoria);
            var ruoka = new Ruoka { Vegan = Vegan, Nimi = Nimi3, Kuvaus = Kuvaus2, Hinta = Hinta, Annos = Annos, AnnosNumero = annosNro };
            kategoria.Ruuat.Add(ruoka);

            yritys.Ruokalista.viimeksiPaivitetty = DateTime.Now;
            db.SaveChanges();

            db.Hintahistoria.Add(new Digiruokalista.com.Models.Hintahistoria { PVM = DateTime.Now, Ruoka = ruoka, Hinta = Hinta });
            db.SaveChanges();

            return RedirectToAction("Muokkaa", yritys);
        }
        public IActionResult PoistaRuoka(int ID, int RuokaID)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var yritys = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).First(o => o.ID == ID && (o.Owner == user || User.IsInRole("Admin")));
            var ruoka = yritys.Ruokalista.Kategoriat.SelectMany(o => o.Ruuat).First(o => o.ID == RuokaID);

            db.Remove(ruoka);

            yritys.Ruokalista.viimeksiPaivitetty = DateTime.Now;
            db.SaveChanges();

            return RedirectToAction("Muokkaa", yritys);
        }

        public IActionResult MuokkaaRuoka(int ID, int RuokaID)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var yritys = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).First(o => o.ID == ID && (o.Owner == user || User.IsInRole("Admin")));
            var ruoka = yritys.Ruokalista.Kategoriat.SelectMany(o => o.Ruuat).First(o => o.ID == RuokaID);

            ViewBag.yritysID = yritys.ID;
            ViewBag.ruokaID = ruoka.ID;

            return View("MuokkaaRuoka", ruoka);
        }
        [HttpPost]
        public IActionResult MuokkaaRuoka(int RuokaID, int YritysID, Ruoka model)
        {
            bool hintaMuuttui = false;
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var yritys = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).First(o => o.ID == YritysID && (o.Owner == user || User.IsInRole("Admin")));
            var ruoka = yritys.Ruokalista.Kategoriat.SelectMany(o => o.Ruuat).First(o => o.ID == RuokaID);

            if(ruoka.Hinta != model.Hinta)
            {
                hintaMuuttui = true;
            }

            ruoka.Nimi = model.Nimi;
            ruoka.Kuvaus = model.Kuvaus;
            ruoka.Hinta = model.Hinta;
            ruoka.Vegan = model.Vegan;
            ruoka.Annos = model.Annos;
            ruoka.AnnosNumero = model.AnnosNumero;

            yritys.Ruokalista.viimeksiPaivitetty = DateTime.Now;
            

            if (hintaMuuttui)
            {
                db.Hintahistoria.Add(new Digiruokalista.com.Models.Hintahistoria { PVM = DateTime.Now, Ruoka = ruoka, Hinta = model.Hinta });
            }

            db.SaveChanges();
            return RedirectToAction("Muokkaa", yritys);
        }
        [AllowAnonymous]
        public IActionResult Katso(int YritysID)
        {
            var yritys = db.Yritys.Include(o => o.Arvostelut).Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).First(o => o.ID == YritysID && o.Ruokalista.piilotettu == false);
            return View("Katso", yritys);
        }
        [AllowAnonymous]
        public IActionResult Arvostele(int YritysID)
        {
            var yritys = db.Yritys.Include(o => o.Arvostelut).Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).First(o => o.ID == YritysID);

            if (yritys.Arvostelut.Where(o => o.source == GetIP()).ToList().Count == 0)
            {
                Arvostelu model = new Arvostelu();
                model.source = GetIP();
                yritys.Arvostelut.Add(model);
                db.SaveChanges();
            }
            else
            {

            }

            return RedirectToAction("Katso", new { YritysID = YritysID });
        }

        public string GetIP()
        {
            string ip = HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return ip;
        }
        [AllowAnonymous]
        public IActionResult GeneroiQR(int YritysID)
        {
            var yritys = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).First(o => o.ID == YritysID);

            Url generator = new Url(Url.Action("Katso", "Ruokalistat", new { YritysID = yritys.ID }, "https"));
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(6);

            QRCodeViewModel viewModel = new QRCodeViewModel { yritys = yritys, qr = ImageToByte2(qrCodeAsBitmap) };

            return View(viewModel);
        }
        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

    }
}
