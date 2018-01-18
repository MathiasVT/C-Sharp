using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum13Mathias
{
    class Wagen
    {
        public Wagen()
        {
            Nummerplaat = string.Empty;
            Merk = string.Empty;
            Schade = 0;
        }
        public Wagen(string _nrplaat, string _merk)
        {
            Nummerplaat = _nrplaat;
            Merk = _merk;
            Schade = 0;
        }

        public string Nummerplaat { get; private set; }
        public string Merk { get; private set; }
        public double Schade { get; set; }
    }
}
