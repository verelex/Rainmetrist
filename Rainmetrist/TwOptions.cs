using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainmetrist
{
    internal class TwOptions
    {
        public string? key { get; set; } // city name
        public string? q { get; set; }   // city id 1 gismeteo
        public string? rph { get; set; } // run per hour
        public string? dhi { get; set; } // default host item
        public string? icl { get; set; } // icon color

        public TwOptions()
        {
            key = String.Empty;
            q = String.Empty;
            rph = String.Empty;
            dhi = String.Empty;
            icl = String.Empty;
        }

        public void SetAll(string k, string qq, string r, string d, string i)
        {
            key = k;
            q = qq;
            rph = r;
            dhi = d;
            icl = i;
        }
    }
}
