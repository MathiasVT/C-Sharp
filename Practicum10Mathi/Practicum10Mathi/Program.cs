using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practicum10Mathi
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {

            
            Console.Clear();
            Console.WriteLine("*******************\n" +
                                  "***  BLACKJACK  ***\n" +
                                  "*******************");
            Blackjack myblackjack = new Blackjack();

            /*Ingeven waarde*/
            do
            {
                Console.Write("Geef je inzet in: ");
                myblackjack.Inzet = double.Parse(Console.ReadLine());
                if (!myblackjack.Inzetten(myblackjack.Inzet))
                {
                    Console.WriteLine("Gelieve een positief getal in te geven");
                }
            }
            while (!myblackjack.Inzetten(myblackjack.Inzet));

            /*Spel*/
            do
            {
                Console.WriteLine("\nTrek een kaart - druk op enter");
                Console.ReadLine();
                string[] kaart = myblackjack.TrekKaart();

                Console.WriteLine("==========================================");
                Console.WriteLine("Getrokken kaart: {0} (Waarde: {1})", kaart[1], kaart[0]);
                Console.WriteLine(myblackjack.GeefOverzicht());
                Console.WriteLine("==========================================");

            }
            while (myblackjack.Totaalkaarten < 21);

            Console.Write("\nOpnieuw (j/n)?: ");
            char keuze = char.Parse(Console.ReadLine().ToLower());
            if(keuze == 'n')
            {
                Console.WriteLine("Afsuiten...");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
          }
            while (true) ;
        }
        
    }
}
