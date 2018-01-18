using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum9
{
    class SimKaart
    {
        public string Code { get; set; }
        public string GsmNummer { get; set; }
        public DateTime CreatieDatum { get; private set; } = DateTime.Now;
        public DateTime LaatsteOproep { get; private set; }
        private int _aantalOproepen;

        public int AantalOproepen

        {
            get { return _aantalOproepen; }
            set { _aantalOproepen = value;
                LaatsteOproep = DateTime.Now;
            }
        }


    }
}
