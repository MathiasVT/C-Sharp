using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac15
{
    class ExpertiseBureau
    {
        private Random _random = new Random();
        public void VoerExpertiseUit(List<Wagen> wagens)
        {
            foreach (Wagen wagen in wagens)
            {
                wagen.Schade += (_random.NextDouble() * 10000);
            }
        }
    }
}
