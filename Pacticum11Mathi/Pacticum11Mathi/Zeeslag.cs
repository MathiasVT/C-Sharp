using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacticum11Mathi
{
    class Zeeslag
    {
        //private
        private Random _random = new Random();
        private int _punten = 0;

        //Constructor
        public Zeeslag()
        {
            MatrixLengte = 5;
            AantalPogingen = 1;
            Boot1 = new Boot();
            Boot2 = new Boot();
            Boot3 = new Boot();

            Boot1.Locatie.X = _random.Next(1, MatrixLengte + 1);
            Boot1.Locatie.Y = _random.Next(1, MatrixLengte + 1);

            Boot2.Locatie.X = _random.Next(1, MatrixLengte + 1);
            Boot2.Locatie.Y = _random.Next(1, MatrixLengte + 1);

            Boot3.Locatie.X = _random.Next(1, MatrixLengte + 1);
            Boot3.Locatie.Y = _random.Next(1, MatrixLengte + 1);

            BotenResterend = Boot.GetAantalBootObjects();
        }

        //Prop
        public Boot Boot1 { get; private set; }
        public Boot Boot2 { get; private set; }
        public Boot Boot3 { get; private set; }

        public int MatrixLengte { get; private set; }


        private int _aantalPogingen;

        public int AantalPogingen
        {
            get { return _aantalPogingen; }
            private set
            {
                _aantalPogingen = value;
                if (value == 0)
                {
                    Afgelopen = true;
                }
            }
        }

        public bool Afgelopen { get; private set; }



        private int _botenResterend;

        public int BotenResterend
        {
            get { return _botenResterend; }
            private set
            {
                _botenResterend = value;
                if (value == 0)
                {
                    Afgelopen = true;
                }
            }
        }


        //Functies
        // Nagaan locatie bom+is het een hit?
        public int SmijtBom(Locatie bom)
        {
            if (Afgelopen)
            {
                return 0;
            }
            else if (bom.X <= MatrixLengte && bom.Y <= MatrixLengte && bom.X > 0 && bom.Y > 0)
            {
                --AantalPogingen;
                if (bom.X == Boot1.Locatie.X && bom.Y == Boot1.Locatie.Y && !Boot1.Gezonken)
                {
                    Boot1.Gezonken = true;
                    _punten += Boot1.Waarde;
                    BotenResterend--;
                    return 2;
                }
                else if (bom.X == Boot2.Locatie.X && bom.Y == Boot2.Locatie.Y && !Boot2.Gezonken)
                {
                    Boot2.Gezonken = true;
                    _punten += Boot2.Waarde;
                    BotenResterend--;
                    return 2;
                }
                else if (bom.X == Boot3.Locatie.X && bom.Y == Boot3.Locatie.Y && !Boot3.Gezonken)
                {
                    Boot3.Gezonken = true;
                    _punten += Boot3.Waarde;
                    BotenResterend--;
                    return 2;
                }
                else
                {
                    // mis
                    return 3;
                }
            }
            else
            {
                // naast domein
                return 1;
            }

        }

        // Grootte matric, kansen, #boten
        public string GeefOmschrijving()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("- SPEL OVERZICHT --------------------------------");
            sb.Append(Environment.NewLine);
            sb.Append("        Matrix lengte:          ");
            sb.Append(MatrixLengte);
            sb.Append(Environment.NewLine);
            sb.Append("        Aantal pogingen:        ");
            sb.Append(AantalPogingen);
            sb.Append(Environment.NewLine);
            sb.Append("        Aantal boten:           ");
            sb.Append(BotenResterend);
            sb.Append(Environment.NewLine);
            sb.Append("-------------------------------------------------");

            return sb.ToString();
        }

        // weergeven restende kansen, aantal punten, aantal boten
        public string GeefStatus()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("- SPEL STATUS -----------------------------------");
            sb.Append(Environment.NewLine);
            sb.Append("        Aantal resterende pogingen:     ");
            sb.Append(AantalPogingen);
            sb.Append(Environment.NewLine);
            sb.Append("        Aantal gewonnen punten:         ");
            sb.Append(_punten);
            sb.Append(Environment.NewLine);
            sb.Append("        Aantal resterende boten:        ");
            sb.Append(BotenResterend);
            sb.Append(Environment.NewLine);
            if (Afgelopen)
            {
                if (BotenResterend == 0)
                {
                    sb.Append("- GEWONNEN - Alle boten werden gezonken!");
                }
                else
                {
                    sb.Append("- VERLOREN - Geen resterende pogingen");
                }
                sb.Append(Environment.NewLine);
            }
            sb.Append("-------------------------------------------------");
            return sb.ToString();
        }
    }
}
