﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ruokalistat.tk.Models;
using System.Collections.Generic;
using System.Linq;

namespace Digiruokalista.com.Controllers
{
    [ApiController]
    public class APIController : Controller
    {
        private tietokantaContext db = new tietokantaContext();
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
    }
}
