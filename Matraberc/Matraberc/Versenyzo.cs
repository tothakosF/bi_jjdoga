using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matraberc
{
    internal class Versenyzo
    {
        public string Nev { get; set; }
        public int Ev { get; set; }
        public string Telepules { get; set; }
        public string Ido { get; set; }
        public string Nem { get; set; }

        public Versenyzo(string sor)
        {
            string[] resz = sor.Split(';');
            Nev= resz[0];
            Ev = Convert.ToInt32(resz[1]);
            Telepules= resz[2];
            Ido= resz[3];
            Nem= resz[4];
        }
    }
}
