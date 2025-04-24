using System;

namespace Tehtävä___C_perusteet_kertaus
{
    class Program
    {
        static Random Random = new Random();

        static int GenerateRandomDmg(int minDmg, int maxDmg)
        {
            return Random.Next(minDmg, maxDmg + 1);
        }
        static void Main()
        {
            int playerHp = 100;
            int enemyHp = 50;

            while (playerHp > 0 && enemyHp > 0)
            {
                Console.WriteLine($"Taistelun tilanne:");
                Console.WriteLine($"Pelaajan terverys: {playerHp}");
                Console.WriteLine($"Örkin terveys: {enemyHp}");
                Console.WriteLine("Kommennot :");
                Console.WriteLine("1. Hyökkää miekalla");
                Console.WriteLine("2. Puolusta kilvellä");

                int playerChoice;
                while (true)
                {
                    Console.Write("Valitse komento (1 tai 2): ");
                    if (int.TryParse(Console.ReadLine(), out playerChoice) && (playerChoice == 1 || playerChoice == 2))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Virheellinen valinta. Valitse uudelleen.");
                    }
                }

                int playerdmg = 0;
                int enemydmg = 0;

                if (playerChoice == 1)
                {
                    playerdmg = GenerateRandomDmg(10, 20);
                    Console.WriteLine($"Ritari hyökkää miekalla ja tekee {playerdmg} vahinkoa!");
                }
                else if (playerChoice == 2)
                {
                    enemydmg = GenerateRandomDmg(5, 10);
                    enemydmg /= 2;
                    Console.WriteLine($"Ritari puolustaa kilvellä ja vähentää örkin tekemää vahinkoa puoleen alkuperäisestä.");
                }

                enemydmg = GenerateRandomDmg(8, 15);
                Console.WriteLine($"Örkki hyökkää ja tekee {enemydmg} vahinkoa!");

                playerHp -= enemydmg;
                enemyHp -= playerdmg;

                Console.WriteLine();

                if (playerHp <= 0)
                {
                    Console.WriteLine("Örkki voitti! Ritari kuoli taistelussa.");
                }
                else if (enemyHp <= 0)
                {
                    Console.WriteLine("Ritari voitti örkin taistelussa. Yippee!");
                }

            }
        }
    }
}
