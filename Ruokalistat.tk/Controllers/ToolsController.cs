using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ruokalistat.tk.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digiruokalista.com.Controllers
{
    public class ToolsController : Controller
    {
        private tietokantaContext db;

        public ToolsController(tietokantaContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ravintolat = await db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).Where(o => o.Ruokalista.piilotettu == false).ToListAsync();
            return View();
        }

        public async Task<JsonResult> GetRuuat(int RavintolaID)
        {
            var yritys = await db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).FirstAsync(o => o.ID == RavintolaID);
            List<Ruoka> ruuat = new List<Ruoka>();
            foreach (var kat in yritys.Ruokalista.Kategoriat)
            {
                ruuat.AddRange(kat.Ruuat);
            }
            return Json(ruuat);
        }

        public async Task<IActionResult> GetHintahistoria(int ravintola, int ruuat, string? paluuOsoite)
        {
            ViewBag.ravintolat = await db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).Where(o => o.Ruokalista.piilotettu == false).ToListAsync();
            ViewBag.hintahistoria = await db.Hintahistoria.Where(o => o.Ruoka.ID == ruuat).ToListAsync();
            ViewBag.valittuRuoka = db.Find<Ruoka>(ruuat).Nimi;
            ViewBag.ravintola = db.Find<Yritys>(ravintola);

            if(paluuOsoite != null && Url.IsLocalUrl(paluuOsoite))
            {
                ViewBag.paluuOsoite = paluuOsoite;
            }

            return View("Index");
        }
    }
}
