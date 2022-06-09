using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ruokalistat.tk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Ruokalistat.tk.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private tietokantaContext db = new tietokantaContext();

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            ViewBag.users = db.AspNetUsers.ToList();
            ViewBag.yritykset = db.Yritys.ToList();
            return View();
        }

        public async Task<IActionResult> PoistaKayttaja(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult VaihdaYrityksenOmistaja(int YritysID, string uusiOmistaja)
        {
            var yritys = db.Yritys.Find(YritysID);
            var user = db.AspNetUsers.Find(uusiOmistaja);

            yritys.Owner = user;

            db.SaveChanges();


            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UusiKayttaja(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true};
            var result = await _userManager.CreateAsync(user, password);


            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> KopioYritys(int YritysID)
        {
            var yritys = db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).First(o => o.ID == YritysID);

            var klooni = new Yritys();

            klooni.Kaupunki = yritys.Kaupunki;
            klooni.Nimi = yritys.Nimi;
            klooni.Osoite = yritys.Osoite;
            klooni.Arvostelut = new List<Arvostelu>();
            klooni.Owner = yritys.Owner;
            klooni.Postinumero = yritys.Postinumero;
            klooni.Puhelin = yritys.Puhelin;
            klooni.yTunnus = yritys.yTunnus;
            klooni.Ruokalista = new Ruokalista();
            klooni.Ruokalista.piilotettu = false;
            klooni.Ruokalista.viimeksiPaivitetty = yritys.Ruokalista.viimeksiPaivitetty;
            klooni.Ruokalista.Kategoriat = new List<Kategoria>();

            foreach(var kat in yritys.Ruokalista.Kategoriat){
                klooni.Ruokalista.Kategoriat.Add(new Kategoria{ Nimi = kat.Nimi, Kuvaus = kat.Kuvaus, Ruuat = new List<Ruoka>() });
                foreach(var ruoka in kat.Ruuat){
                    klooni.Ruokalista.Kategoriat.First(o => o.Nimi == kat.Nimi).Ruuat.Add(new Ruoka{ Nimi = ruoka.Nimi, Hinta = ruoka.Hinta, Annos = ruoka.Annos, Kuvaus = ruoka.Kuvaus, Vegan = ruoka.Vegan, AnnosNumero = ruoka.AnnosNumero});
                }
            }
            db.Yritys.Add(klooni);
            db.SaveChanges();
            return RedirectToAction("Muokkaa", "Ruokalistat", new{ ID = klooni.ID });
        }
    }
}
