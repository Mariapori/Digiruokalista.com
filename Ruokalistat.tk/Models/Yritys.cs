using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ruokalistat.tk.Models
{
    public class Yritys
    {
        public int ID { get; set; }
        [Required]
        public string Nimi { get; set; }
        [Required]
        public string yTunnus { get; set; }
        [Required]
        public string Osoite { get; set; }
        [Required]
        public string Postinumero { get; set; }
        [Required]
        public string Kaupunki { get; set; }
        public string VapaaTeksti {get;set;}
        public string Puhelin { get; set; }
        public Ruokalista Ruokalista { get; set; }
        public string Owner { get; set; }
        public List<Arvostelu> Arvostelut {get;set;}
    }

    public class Ruokalista
    {
        public int ID { get; set; }
        public List<Kategoria> Kategoriat { get; set; }
        public DateTime viimeksiPaivitetty { get; set; }
        [Required]
        public bool piilotettu { get; set; }
        
        public int? RuuatCount
        {
            get { return this.Kategoriat?.Sum(o => o.Ruuat?.Where(o => o.Annos == true).ToList().Count); }
        }
    }

    public class Kategoria
    {
        public int ID { get; set; }
        [Required]
        public string Nimi { get; set; }
        public string Kuvaus { get; set; }
        public List<Ruoka> Ruuat { get; set; }
    }

    public class Ruoka
    {
        public int ID { get; set; }
        [Required]
        public string Nimi { get; set; }
        public int AnnosNumero {get;set;}
        public string Kuvaus { get; set; }
        public bool Vegan { get; set; }
        [Required]
        public decimal Hinta { get; set; }
        public bool Annos { get; set; }
    }
    public class Arvostelu
    {
        public int ID {get;set;}
        public Yritys yritys {get;set;}
        public string source { get; set; }
    }
}
