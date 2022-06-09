using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace Ruokalistat.tk.Models
{
    public class QRCodeViewModel
    {
        public Yritys yritys { get; set; }
        public byte[] qr { get; set; }
    }
}
