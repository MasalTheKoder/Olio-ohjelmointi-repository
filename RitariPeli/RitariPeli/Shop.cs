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
                    bool canBuy = true;

                    if (item is Weapon weapon)
                        canBuy = knight.EquippedWeapon == null || knight.EquippedWeapon.Name != weapon.Name;

                    if (item is Armor armor)
                        canBuy = knight.EquippedArmor == null || knight.EquippedArmor.Name != armor.Name;

                    string availability = canBuy ? "" : " (omistat tämän)";
                    Console.WriteLine($"{i + 1}. {item.Name} - {item.Price} kultaa{availability}");
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

                        bool alreadyOwned = false;

                        if (selectedItem is Weapon selectedWeapon)
                            alreadyOwned = knight.EquippedWeapon != null && knight.EquippedWeapon.Name == selectedWeapon.Name;

                        if (selectedItem is Armor selectedArmor)
                            alreadyOwned = knight.EquippedArmor != null && knight.EquippedArmor.Name == selectedArmor.Name;

                        if (alreadyOwned)
                        {
                            Console.WriteLine("Sinulla on jo tämä item!");
                        }
                        else if (knight.Gold >= selectedItem.Price)
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
