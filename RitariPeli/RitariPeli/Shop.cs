using System;
using System.Collections.Generic;

namespace RitariPeli
{
    public class Shop
    {
        private List<Item> itemsForSale;

        public Shop()
        {
            itemsForSale = new List<Item>()
            {
                new Weapon("Miekka", 50, 10),
                new Weapon("Parempi miekka", 80, 15),
                new Armor("Haarniska", 40, 5),
                new Armor("Parempi haarniska", 70, 10),
                new Potion("Parannusjuoma", 20, 30),
                new Potion("Parempi parannusjuoma", 35, 60)
            };
        }

        public void OpenShop(Knight knight)
        {
            bool shopping = true;

            while (shopping)
            {
                Console.Clear();
                Console.WriteLine("=== KAUPPA ===");
                Console.WriteLine($"Sinulla on {knight.Gold} kultaa.\n");

                for (int i = 0; i < itemsForSale.Count; i++)
                {
                    Item item = itemsForSale[i];
                    Console.WriteLine($"{i + 1}. {item.Name} - {item.Price} kultaa");
                }
                Console.WriteLine("0. Poistu kaupasta");
                Console.Write("\nValitse ostettava tuote: ");

                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice))
                {
                    if (choice == 0)
                    {
                        shopping = false;
                        Console.WriteLine("Poistutaan kaupasta...");
                        Console.ReadLine();
                    }
                    else if (choice > 0 && choice <= itemsForSale.Count)
                    {
                        Item selectedItem = itemsForSale[choice - 1];

                        if (knight.Gold >= selectedItem.Price)
                        {
                            knight.Gold -= selectedItem.Price;

                            if (selectedItem is Potion potion)
                            {
                                knight.Potions.Add(potion);
                                Console.WriteLine($"Ostit {potion.Name} ja se lisättiin inventoriin.");
                            }
                            else
                            {
                                selectedItem.Use(knight);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sinulla ei ole tarpeeksi kultaa!");
                        }

                        Console.WriteLine("Paina Enter jatkaaksesi.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Virheellinen valinta.");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
