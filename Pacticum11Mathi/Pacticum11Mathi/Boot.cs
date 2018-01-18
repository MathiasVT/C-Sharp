using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacticum11Mathi
{
    class Boot
    {
        private static int botencounter = 0;
        public Boot()
        {
            botencounter++;
        }

        ~Boot()
        {
            botencounter--;
        }

        public Locatie Locatie { get; private set; } = new Locatie();
        public bool Gezonken { get; set; } = false;
        public int Waarde { get; private set; } = new Random(Guid.NewGuid().GetHashCode()).Next(1, 6);

        public static int GetAantalBootObjects()
        {
            return botencounter;
        }
    }
}
