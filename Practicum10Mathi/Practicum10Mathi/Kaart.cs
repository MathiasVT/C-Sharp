using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum10Mathi
{
    class Kaart
    {
        public Kaart()
        { 
            Waarde = new Random().Next(1,14);
            switch (Waarde)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    Omschrijving = Waarde.ToString();
                    break;
                case 11:
                    Omschrijving = "Boer";
                    break;
                case 12:
                    Omschrijving = "Dame";
                    break;
                case 13:
                    Omschrijving = "Heer";
                    break;

            }

          }
        public int Waarde { get; private set; }
        public string Omschrijving { get; private set; }
        }
}
