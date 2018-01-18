using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacticum11Mathi
{
    class Program
    {
        static void Main(string[] args)
        {
            Zeeslag zeeslag = new Zeeslag();
            Locatie bom = new Locatie();

            Console.WriteLine(zeeslag.GeefOmschrijving());
            Console.WriteLine("\nDruk op een toets om het spel te starten");
            Console.ReadLine();

            do
            {
                Console.Clear();
                Console.WriteLine(zeeslag.GeefStatus());
                if (!zeeslag.Afgelopen)
                {
                    Console.WriteLine("\nSmijt een bom! Geef de X en Y coordinaten in");

                    string stringX;
                    int bomX;

                    do
                    {
                        Console.Write("X: ");
                        stringX = Console.ReadLine();
                    } while (!int.TryParse(stringX, out bomX));
                    bom.X = bomX;

                    string stringY;
                    int bomY;
                    do
                    {
                        Console.Write("Y: ");
                        stringY = Console.ReadLine();
                    } while (!int.TryParse(stringY, out bomY));
                    bom.Y = bomY;
                }

                Console.WriteLine();

                switch (zeeslag.SmijtBom(bom))
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine(zeeslag.GeefStatus());
                        Console.WriteLine("\n\nDruk op een toets om af te sluiten");
                        Console.ReadLine();
                        Console.WriteLine("Afsluiten...");
                        System.Threading.Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.WriteLine("Verkeerde coordinaten. Maximum waarde = " + zeeslag.MatrixLengte);
                        break;
                    case 2:
                        Console.WriteLine("RAAK!!");
                        break;
                    case 3:
                        Console.WriteLine("MIS!!");
                        break;
                }


                Console.WriteLine("Druk op een toets");
                Console.ReadLine();
            } while (true);
        }
    }
}
