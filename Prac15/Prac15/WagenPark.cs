using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac15
{
    class WagenPark
    {
        public WagenPark()
        {
            Wagens = new List<Wagen>();
        }

        public List<Wagen> Wagens { get; set; }

        public bool SchrijfWagenIn(ref Wagen wagen)
        {
            if (wagen.Nummerplaat == string.Empty)
            {
                return false;
            }
            Wagens.Add(wagen);
            return true;
        }

        public string GeefOverzicht()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("*** Wagenpark Overzicht ***");
            sb.Append(Environment.NewLine);
            foreach (Wagen wagen in Wagens)
            {
                sb.Append(" - ");
                sb.Append(wagen.Nummerplaat);
                sb.Append(" / Merk: ");
                sb.Append(wagen.Merk);
                sb.Append(" / Schade: ");
                sb.Append(wagen.Schade.ToString("0.00"));
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public Wagen ZoekWagen(string _nummerplaat)
        {
            return Wagens.Find(x => x.Nummerplaat == _nummerplaat);
        }
    }
}
