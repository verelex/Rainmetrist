using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rainmetrist
{
    internal class TwHosts
    {
        public string? hst { get; set; }
        public string? cls { get; set; }

        public TwHosts()
        {
            hst = String.Empty;
            cls = String.Empty;
        }

        public void SetAll(string h, string c)
        {
            hst = h;
            cls = c;
        }
    }
}
