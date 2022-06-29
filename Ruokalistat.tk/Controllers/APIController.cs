using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ruokalistat.tk.Models;
using System.Collections.Generic;
using System.Linq;

namespace Digiruokalista.com.Controllers
{
    [ApiController]
    public class APIController : Controller
    {
        private tietokantaContext db;
        public APIController(tietokantaContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("api/v1/HaeYritykset")]
        public List<Yritys> HaeYritykset()
        {
            return db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).OrderBy(o => o.Nimi).Where(o => o.Ruokalista.piilotettu == false).ToList();
        }
        [HttpGet]
        [Route("api/v1/HaeYritys")]
        public Yritys HaeYritys(int id)
        {
            return db.Yritys.Include(o => o.Ruokalista).ThenInclude(o => o.Kategoriat).ThenInclude(o => o.Ruuat).OrderBy(o => o.Nimi).Where(o => o.Ruokalista.piilotettu == false).FirstOrDefault(o => o.ID == id);
        }
        [HttpGet]
        [Route("api/v1/HaeTykkaykset")]
        public int HaeTykkaykset(int YritysID){
            var yritys = db.Yritys.Include(o => o.Arvostelut).FirstOrDefault(o => o.ID == YritysID);
            return yritys?.Arvostelut.Count() ?? 0;
        }
    }
}
