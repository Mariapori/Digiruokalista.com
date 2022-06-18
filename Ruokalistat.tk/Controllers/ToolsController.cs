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
        private readonly tietokantaContext db = new tietokantaContext();
        public async Task<IActionResult> Index()
        {
            ViewBag.ravintolat = await db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).ToListAsync();
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

        public async Task<IActionResult> GetHintahistoria(int ravintola,int ruuat)
        {
            ViewBag.ravintolat = await db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).ToListAsync();
            ViewBag.hintahistoria = await db.Hintahistoria.Where(o => o.Ruoka.ID == ruuat).ToListAsync();
            return View("Index");
        }
    }
}
