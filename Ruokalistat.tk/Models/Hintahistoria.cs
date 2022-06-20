
using System;
using System.Collections.Generic;

namespace Digiruokalista.com.Models
{
    public class Hintahistoria
    {
        public int ID { get; set; }
        public Ruokalistat.tk.Models.Ruoka Ruoka { get; set; }
        public decimal Hinta { get; set; }
        public DateTime PVM { get; set; }
    }
}
