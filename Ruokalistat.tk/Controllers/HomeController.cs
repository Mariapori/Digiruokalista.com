using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ruokalistat.tk.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using AspNetCore.SEOHelper;

namespace Ruokalistat.tk.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;
        private tietokantaContext db;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env, tietokantaContext db)
        {
            _logger = logger;
            _env = env;
            this.db = db;
        }
        public IActionResult Index()
        {
            CreateSitemapInRootDirectory();
            return View();
        }

        public IActionResult OtaYhteytta()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string CreateSitemapInRootDirectory()  
        {  
            if(System.IO.File.Exists(System.IO.Path.Combine(_env.ContentRootPath,"sitemap.xml")))
            {
            System.IO.File.Delete(System.IO.Path.Combine(_env.ContentRootPath,"sitemap.xml"));
            }
            var list = new List<AspNetCore.SEOHelper.Sitemap.SitemapNode>();  
            var yritykset = db.Yritys.ToList();

            list.Add(new AspNetCore.SEOHelper.Sitemap.SitemapNode{LastModified = DateTime.UtcNow, Priority = 1, Url = Url.Action("Index","Home",null,"https")});
            list.Add(new AspNetCore.SEOHelper.Sitemap.SitemapNode{LastModified = DateTime.UtcNow, Priority = 0.8, Url = Url.Action("Index","Ruokalistat",null,"https")});
            list.Add(new AspNetCore.SEOHelper.Sitemap.SitemapNode{LastModified = DateTime.UtcNow, Priority = 0.8, Url = Url.Action("OtaYhteytta","Home",null,"https")});

            double juttu = 0.7;
            foreach(var yritys in yritykset)
            {
                list.Add(new AspNetCore.SEOHelper.Sitemap.SitemapNode{LastModified = DateTime.UtcNow, Priority = juttu, Url = Url.Action("Katso","Ruokalistat",new { YritysID = yritys.ID } ,"https")});
            }
            
            new AspNetCore.SEOHelper.Sitemap.SitemapDocument().CreateSitemapXML(list,_env.ContentRootPath);  
            return "sitemap.xml file should be create in root directory";  
        }   
    }
}
