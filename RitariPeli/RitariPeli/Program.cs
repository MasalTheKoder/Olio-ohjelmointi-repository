using System;

namespace RitariPeli
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== RITARI PELI ===");
                Console.WriteLine("1. Aloita taistelu.");
                Console.WriteLine("2. Käy kaupassa.");
                Console.WriteLine("3. Lopeta peli");
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
                        break;
                    default:
                        Console.WriteLine("Virheellinen valinta");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void EnterBattle()
        {
            Console.Clear();
            Console.WriteLine("Taistelu alkaa!");
            Console.WriteLine("Paina Enter palataksesi menuun.");
            Console.ReadLine();
        }

        static void VisitShop()
        {
            Console.Clear();
            Console.WriteLine("Tervetuloa Kauppaan!");
            Console.WriteLine("Paina Enter palataksesi menuun");
            Console.ReadLine();
        }
    }
}
