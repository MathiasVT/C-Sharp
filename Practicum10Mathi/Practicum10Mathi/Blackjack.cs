using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum10Mathi
{
    class Blackjack
    {
        int _statusInt;

        public Blackjack()
        {
            _statusInt = 1;
        }

        public int Totaalkaarten { get; private set; }
        public double Inzet { get; set; }
        public string[] Spelstatus { get; } = { "verloren", "spel gestart", "gewonnen" };

        public string [] TrekKaart()
        {
            Kaart kaart = new Kaart();
            string[] card = new string[2];
            card[0] = kaart.Waarde.ToString();
            card[1] = kaart.Omschrijving;
            Totaalkaarten += kaart.Waarde;
            if (Totaalkaarten == 21)
            {
                _statusInt++;
            }
            return card;
        }

        public bool Inzetten (double inzet)
        {
            if(inzet<0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string GeefOverzicht()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Spel overzicht:\n Inzet: ");
            sb.Append(Inzet);
            sb.Append("\n Totaal kaarten:  ");
            sb.Append(Totaalkaarten);
            sb.Append("\n Status: ");
            sb.Append(Spelstatus[_statusInt]);
            if (_statusInt ==2)
            {
                sb.Append(" - Winst = ");
                sb.Append(Inzet * 2);
            }
            if (_statusInt==0)
            {
                sb.Append(" - Verlies = ");
                sb.Append(Inzet);
            }
            return sb.ToString();
        }
    }
}
