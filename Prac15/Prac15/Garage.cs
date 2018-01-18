using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac15
{
    class Garage
    {
        Random _random = new Random();
        public Garage()
        {
            Naam = string.Empty;
            Merk = string.Empty;
        }

        public Garage(string _naam, string _merk)
        {
            Naam = _naam;
            Merk = _merk;
        }

        public string Naam { get; private set; }
        public string Merk { get; private set; }

        public double RepareerWagen(ref Wagen _wagen)
        {
            double _schade = _wagen.Schade;
            _wagen.Schade = 0;
            return _schade;
        }
    }
}
