using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practicum9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** GSM Box - initialisatie ***");
            Console.WriteLine("Gelieve de gegevens in te geven van de 2 toe te voegen SIM Kaarten");

            GsmBox box = new GsmBox();
            box.SimKaart1 = new SimKaart();
            Console.WriteLine("\n  SIM 1");
            Console.Write("   - Code: ");
            box.SimKaart1.Code = Console.ReadLine().ToUpper();
            Console.Write("   - GSM Nummer: ");
            box.SimKaart1.GsmNummer = Console.ReadLine();
            Console.WriteLine(box.SimKaart1.Code + " werd toegevoegd aan de GSM Box");

            box.SimKaart2 = new SimKaart();
            Console.WriteLine("\n  SIM 2");
            Console.Write("   - Code: ");
            box.SimKaart2.Code = Console.ReadLine().ToUpper();
            Console.Write("   - GSM Nummer: ");
            box.SimKaart2.GsmNummer = Console.ReadLine();
            Console.WriteLine(box.SimKaart2.Code + " werd toegevoegd aan de GSM Box");

            Console.WriteLine("Druk op enter om de GSM Box te gebruiken");
            Console.ReadLine();

            //menu
            do
            {
                Console.Clear();
                Console.WriteLine("** GSM Box - Menu ***");
                Console.WriteLine("1. gegevens van SIM Kaarten opvragen");
                Console.WriteLine("2. Bellen met SIM Kaarten");
                Console.WriteLine("3. Afsluiten");


                int keuze = int.Parse(Console.ReadLine());

                switch (keuze)
                {
                    case 1:
                        Console.WriteLine("SIM 1");
                        Console.WriteLine(" - Code\t\t\t\t: " + box.SimKaart1.Code);
                        Console.WriteLine(" - GSM nummer\t\t\t: " + box.SimKaart1.GsmNummer);
                        Console.WriteLine(" - Installatiedatum\t\t: " + box.SimKaart1.CreatieDatum);
                        Console.WriteLine(" - Datum laatste oproep\t\t: " + box.SimKaart1.LaatsteOproep);
                        Console.WriteLine(" - Aantal oproepen\t\t: " + box.SimKaart1.AantalOproepen);

                        Console.WriteLine("\nSIM 2");
                        Console.WriteLine(" - Code\t\t\t\t: " + box.SimKaart2.Code);
                        Console.WriteLine(" - GSM nummer\t\t\t: " + box.SimKaart2.GsmNummer);
                        Console.WriteLine(" - Installatiedatum\t\t: " + box.SimKaart2.CreatieDatum);
                        Console.WriteLine(" - Datum laatste oproep\t\t: " + box.SimKaart2.LaatsteOproep);
                        Console.WriteLine(" - Aantal oproepen\t\t: " + box.SimKaart2.AantalOproepen);

                        break;
                    case 2:

                        Console.Write("\nMet welke SIM kaart wil je bellen (geef de correcte code in): ");
                        string keuzeCode = Console.ReadLine().ToUpper();
                        if (keuzeCode == box.SimKaart1.Code)
                        {
                            Console.WriteLine("De oproep met SIM "+box.SimKaart1.Code+ " is tot stand gebracht");
                            box.SimKaart1.AantalOproepen++;
                            
                        }
                        else if (keuzeCode == box.SimKaart2.Code)
                        {
                            Console.WriteLine("De oproep met SIM " + box.SimKaart2.Code + " is tot stand gebracht");
                            box.SimKaart2.AantalOproepen++;
                        }
                        else
                        {
                            Console.WriteLine("Code SIM Kaart niet gekend");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Afsluiten...");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;


                    default:
                        Console.WriteLine("Ongeldige Optie");
                        break;

                }
                Console.WriteLine("Druk op Enter om verder te gaan");
                Console.ReadLine();

            } while (true);

        }
    }
}
