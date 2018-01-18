using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum13Mathias
{
    class Program
    {
        static void Main(string[] args)
        {
            WagenPark wagenpark = new WagenPark();
            ExpertiseBureau eb = new ExpertiseBureau();
            Garages garages = new Garages();

            do
            {
                Console.Clear();
                Console.WriteLine("*** Wagenpark beheer***");
                Console.WriteLine("1. Voeg een wagen toe***");
                Console.WriteLine("2. Geef wagenpark overzicht");
                Console.WriteLine("3. Voer expertise uit");
                Console.WriteLine("4. Voeg garage toe");
                Console.WriteLine("5. Repareer wagen");
                Console.WriteLine("6. Stop");

                int Choice;
                bool Correct;
                do
                {
                    Console.Write(" > ");
                    Correct = int.TryParse(Console.ReadLine(), out Choice);
                } while (!Correct);


                switch (Choice)
                {
                    case 1:
                        Wagen wagen = new Wagen();
                        Console.Write("Geef de nummerplaat van de wagen: ");
                        string nrplaat = Console.ReadLine().ToUpper();
                        Console.Write("Geef het merk van de wagen: ");
                        string merk = Console.ReadLine();
                        wagen = new Wagen(nrplaat, merk);
                        if (wagenpark.SchrijfWagenIn(ref wagen))
                        {
                            Console.WriteLine("Wagen met nummerplaat {0} werd toegevoegd.", wagen.Nummerplaat);
                        }
                        else
                        {
                            Console.WriteLine("De wagen werd niet aan het wagenpark toegevoegd - blanco nummerplaat niet toegelaten");
                        }
                        break;
                    case 2:
                        Console.WriteLine(wagenpark.GeefOverzicht());
                        break;
                    case 3:
                        eb.VoerExpertiseUit(wagenpark.Wagens);
                        Console.WriteLine("De expertise op het wagenpark werd uitgevoerd");
                        break;
                    case 4:
                        Garage garage;
                        Console.Write("Geef de naam van de garage: ");
                        string _naam = Console.ReadLine();
                        Console.Write("Geef het merk van de garage: ");
                        string _merk = Console.ReadLine();
                        garage = new Garage(_naam, _merk);
                        garages.AutoGarages.Add(garage);
                        Console.WriteLine("Garage {0} {1} werd toegevoegd.", garage.Naam, garage.Merk);
                        break;
                    case 5:
                        Console.Write("Geef de nummerplaat in van de te repareren wagen: ");
                        string _nrpl = Console.ReadLine().ToUpper();
                        Wagen w = wagenpark.ZoekWagen(_nrpl);

                        if (w != null)
                        {
                            Garage gar = garages.AutoGarages.FirstOrDefault(g => g.Merk.ToUpper() == w.Merk.ToUpper());
                            if (gar != null)
                            {
                                Console.WriteLine("De wagen werd gerapereerd door garage {0} {1} Totale kost: {2:0.00}",
                                    gar.Naam, gar.Merk, gar.RepareerWagen(ref w));
                            }
                            else
                            {
                                Console.WriteLine("Er werd geen garage gevonden voor het merk {0}", w.Merk);
                            }
                        }
                        else
                        {
                            Console.WriteLine("De wagen met nummerplaat {0} werd niet gevonden", _nrpl);
                        }
                        break;
                    case 6:
                        Console.WriteLine("Afsluiten...");
                        System.Threading.Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Foute menukeuze, geef een nummer in (1-6)");
                        break;
                }
                Console.WriteLine("Druk op een toets om verder te gaan");
                Console.ReadLine();
            } while (true);

            

            

        }
    }
}
