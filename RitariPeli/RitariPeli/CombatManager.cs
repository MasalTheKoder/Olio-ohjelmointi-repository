using System;
using System.Threading;

namespace RitariPeli
{
    public class CombatManager
    {
        private Knight player;
        private Enemy enemy;

        public CombatManager(Knight player)
        {
            this.player = player;
        }

        public void StartCombat()
        {
            Console.Clear();

            bool validChoice = false;
            while (!validChoice)
            {
                Console.WriteLine("Valitse vihollinen:");
                Console.WriteLine("1. Paha (Helppo)");
                Console.WriteLine("2. Iso Paha (Vaikea)");
                Console.Write("Valintasi: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        enemy = new Enemy("Paha", 30, 5);
                        validChoice = true;
                        break;
                    case "2":
                        enemy = new Enemy("Iso Paha", 50, 10);
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Virheellinen valinta.\n");
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Taistelu alkaa!");
            Console.WriteLine($"{player.Name} vs {enemy.Name}\n");

            while (player.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                PlayerTurn();
                if (enemy.CurrentHealth <= 0) break;

                EnemyTurn();
            }

            if (player.CurrentHealth > 0)
            {
                Console.WriteLine($"\n{player.Name} voitti taistelun!");
                player.Gold += 40;
                Console.WriteLine($"{player.Name} sai 40 kultaa palkkioksi!");
            }
            else
            {
                Console.WriteLine($"\n{player.Name} hävisi taistelun...");
            }

            Console.WriteLine("\nPaina Enter jatkaaksesi...");
            Console.ReadLine();
        }

        private void PlayerTurn()
        {
            bool turnDone = false;

            while (!turnDone)
            {
                Console.WriteLine($"\n{player.Name} HP: {player.CurrentHealth} | {enemy.Name} HP: {enemy.CurrentHealth}");
                Console.WriteLine("1. Hyökkää");
                Console.WriteLine("2. Käytä potionia");
                Console.Write("Valintasi: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        int attack = 10 + (player.EquippedWeapon?.AttackBonus ?? 0);
                        enemy.CurrentHealth -= attack;
                        if (enemy.CurrentHealth < 0) enemy.CurrentHealth = 0;

                        Console.WriteLine($"{player.Name} hyökkäsi ja teki {attack} damagea!");
                        turnDone = true;
                        Thread.Sleep(1000);
                        break;

                    case "2":
                        if (player.Potions.Count > 0)
                        {
                            Potion potion = player.Potions[0];
                            potion.Use(player);
                            player.Potions.RemoveAt(0);
                            turnDone = true;
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            Console.WriteLine("Sinulla ei ole potioneita!");
                        }
                        break;

                    default:
                        Console.WriteLine("Virheellinen valinta.");
                        break;
                }
            }
        }

        private void EnemyTurn()
        {
            int defense = player.EquippedArmor?.DefenseBonus ?? 0;
            int damage = enemy.AttackPower - defense;
            if (damage < 0) damage = 0;

            player.CurrentHealth -= damage;
            if (player.CurrentHealth < 0) player.CurrentHealth = 0;

            Console.WriteLine($"{enemy.Name} teki {damage} damagea!");
            Thread.Sleep(1000);
        }
    }
}
