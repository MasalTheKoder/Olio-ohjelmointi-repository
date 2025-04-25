using System;

namespace RitariPeli
{
    class Program
    {
        static Knight player;
        static Shop shop;

        static void Main(string[] args)
        {
            Console.Write("Mikä on nimesi? ");
            string name = Console.ReadLine();
            player = new Knight(name);
            shop = new Shop();

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== RITARIN SEIKKAILU ===");
                player.ShowStats();
                Console.WriteLine("\nMitä haluat tehdä?");
                Console.WriteLine("1. Mene taisteluun");
                Console.WriteLine("2. Vieraile kaupassa");
                Console.WriteLine("3. Poistu pelistä");
                Console.Write("Valintasi: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        EnterBattle();
                        break;
                    case "2":
                        VisitShop();
                        break;
                    case "3":
                        isRunning = false;
                        Console.WriteLine("Kiitos pelaamisesta!");
                        break;
                    default:
                        Console.WriteLine("Virheellinen valinta. Paina Enter jatkaaksesi.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void EnterBattle()
        {
            Console.Clear();
            Console.WriteLine("Aloitetaan taistelu... (tähän tulee taistelulogiikka myöhemmin)");
            Console.WriteLine("Paina Enter palataksesi valikkoon.");
            Console.ReadLine();
        }

        static void VisitShop()
        {
            shop.OpenShop(player);
        }
    }
}
