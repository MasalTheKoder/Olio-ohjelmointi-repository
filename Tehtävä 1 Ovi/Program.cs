using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum OvenTila
{
    Kiinni = 1,
    Auki = 2,
    Lukossa = 3,
}
namespace Tehtävä_1_Ovi
{
    class Program
    {
        static void Main(string[] args)
        {
            OvenTila ovenTila = OvenTila.Kiinni;

            while (true)
            {
                Console.WriteLine("Oven tila: " + ovenTila);

                Console.Write("Anna komento (Avaa lukko, Avaa, Sulje, Lukitse): ");
                string komento = Console.ReadLine().ToLower();

                switch (komento)
                {
                    case "avaa lukko": 
                        if (ovenTila == OvenTila.Lukossa)
                        {
                            ovenTila = OvenTila.Kiinni;
                            Console.WriteLine("Oven lukko avattu. ");
                        }
                        else
                        {
                            Console.WriteLine("Oven lukko on jo avattu tai ovi ei ole kiinni.");
                        }
                        break;

                    case "avaa":
                        if (ovenTila == OvenTila.Kiinni)
                        {
                            ovenTila = OvenTila.Auki;
                            Console.WriteLine("Ovi avattu.");
                        }
                        else
                        {
                            Console.WriteLine("Ovea ei voi avata.");
                        }
                        break;

                    case "sulje":
                        if (ovenTila == OvenTila.Auki)
                        {
                            ovenTila = OvenTila.Kiinni;
                            Console.WriteLine("Ovi suljettu");
                        }
                        else
                        {
                            Console.WriteLine("Ovea ei voida sulkea");
                        }
                        break;

                    case "lukitse":
                        if (ovenTila == OvenTila.Kiinni)
                        {
                            ovenTila = OvenTila.Lukossa;
                            Console.WriteLine("Ovi lukittu");
                        }
                        else
                        {
                            Console.WriteLine("Ovea ei voida lukita.");
                        }
                        break;

                    default:
                        Console.WriteLine("Tuntematon komento. Yritä uudelleen.");
                        break;
                }
            }
        }
    }
}
