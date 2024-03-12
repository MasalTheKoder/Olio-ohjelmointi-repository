using System;
using System.Collections.Generic;
using System.Threading;

namespace Peli
{
    class Program
    {
        static void Main(string[] args)
        {
            Ritari ritari = new Ritari("Ritari", 10, 100);
            Kauppa kauppa = new Kauppa();
            kauppa.LisääItem(new Ase("Miekka", 10, 10));
            kauppa.LisääItem(new Haarniska("Kilpi", 3, 15));
            kauppa.LisääItem(new Taikajuoma("Parannusjuoma", 20, 5));
            Kulta kulta = new Kulta(20);

            Random random = new Random();
            Day day = new Day();

            while (true)
            {
                Console.WriteLine($"Päivä on {day.day}\n");
                Console.WriteLine("Kultaa: " + kulta.Määrä);
                Console.WriteLine("Pelaajan ominaisuudet:");
                Console.WriteLine($"Nimi: {ritari.Nimi}, Terveys: {ritari.Terveys}\n");
                Console.WriteLine("Omistetut esineet:");
                Console.WriteLine($"Ase: {(ritari.Ase != null ? ritari.Ase.GetNimi() : "Ei mitään")}");
                Console.WriteLine($"Haarniska: {(ritari.Haarniska != null ? ritari.Haarniska.GetNimi() : "Ei mitään")}");
                Console.WriteLine($"Taikajuoma: {(ritari.Taikajuoma != null ? ritari.Taikajuoma.GetNimi() : "Ei mitään")}\n");
                Console.WriteLine("1. Taistele vihollista vastaan");
                Console.WriteLine("2. Vieraile kaupassa");
                Console.WriteLine("Valitse toiminto (1 tai 2):");
                string valinta = Console.ReadLine();

                if (valinta == "1")
                {
                    Vihollis vihollinen = ValitseSatunnainenVihollinen(random, day.day);

                    bool skipTurn = false;
                    bool doubleDamage = false;

                    while (ritari.Terveys > 0 && vihollinen.Terveys > 0)
                    {
                        Thread.Sleep(750);

                        Console.WriteLine($" {ritari.Nimi} vs {vihollinen.Nimi}\n");

                        if (doubleDamage)
                        {
                            ritari.OtaVahinkoa(vihollinen.Voima * 2);
                            Console.WriteLine($"{vihollinen.Nimi} hyökkää kaksi kertaa ja tekee tuplaa vahinkoa!\n");
                            doubleDamage = false;
                        }
                        else
                        {
                            ritari.OtaVahinkoa(vihollinen.Voima);
                        }

                        if (vihollinen.Terveys <= 0)
                        {
                            Console.WriteLine($"{vihollinen.Nimi} Päihitetty!");
                            if (ritari.Taikajuoma != null)
                            {
                                Console.WriteLine($"{ritari.Nimi} Käytti Hp potionin joten Ritarin health on {ritari.Terveys} + 20");
                                ritari.OtaVahinkoa(-20);
                                ritari.Taikajuoma = null;
                            }
                            Console.WriteLine($"Ritarin Hp: {ritari.Terveys}");
                            day.day++;
                            kulta.LisääKultaa(10);
                            break;
                        }

                        Thread.Sleep(1000);

                        if (!skipTurn)
                        {
                            vihollinen.OtaVahinkoa(ritari.Ase != null ? ritari.Ase.Vahinko : 5);
                            if (vihollinen.Terveys <= 0)
                            {
                                Console.WriteLine($"{vihollinen.Nimi} Päihitetty!");
                                if (ritari.Taikajuoma != null)
                                {
                                    Console.WriteLine($"{ritari.Nimi} Käytti Hp potionin joten Ritarin health on {ritari.Terveys} + 20");
                                    ritari.OtaVahinkoa(-20);
                                    ritari.Taikajuoma = null;
                                }
                                Console.WriteLine($"Ritarin Hp: {ritari.Terveys}");
                                day.day++;
                                kulta.LisääKultaa(10);
                                break;
                            }
                        }

                        ritari.OtaVahinkoa(vihollinen.Voima);
                        if (ritari.Terveys <= 0)
                        {
                            Console.WriteLine("Ritari kuoli, Hävisit...");
                            Thread.Sleep(2000);
                            return;
                        }

                        Console.WriteLine($"Ritarin Hp: {ritari.Terveys}");
                        Console.WriteLine($"Vihollisen Hp: {vihollinen.Terveys}\n");

                        skipTurn = !skipTurn;

                        if (random.Next(1, 101) <= 25)
                        {
                            doubleDamage = true;
                            Console.WriteLine($"{vihollinen.Nimi} saa ylimääräisen hyökkäyksen seuraavalla vuorolla!\n");
                        }
                    }
                }
                else if (valinta == "2")
                {
                    Console.WriteLine("Tervetuloa shoppiin!");
                    Console.WriteLine("Kultaa: " + kulta.Määrä);
                    Console.WriteLine("Myynnissä:");
                    foreach (Item item in kauppa.shopItems)
                    {
                        Console.WriteLine(item.GetNimi() + " - " + kauppa.GetItemHinta(item) + " kultaa");
                    }

                    Console.WriteLine("Mitä haluaisit ostaa?");
                    string ostos = Console.ReadLine();
                    Item ostettuItem = kauppa.OstaItem(ostos, kulta);

                    if (ostettuItem != null)
                    {
                        if (ostettuItem is Ase)
                        {
                            ritari.Ase = (Ase)ostettuItem;
                            Console.WriteLine($"\nOstit aseen: {ostettuItem.GetNimi()}\n");
                        }
                        else if (ostettuItem is Haarniska)
                        {
                            ritari.Haarniska = (Haarniska)ostettuItem;
                            Console.WriteLine($"\nOstit haarniskan: {ostettuItem.GetNimi()}\n");
                        }
                        else if (ostettuItem is Taikajuoma)
                        {
                            ritari.Taikajuoma = (Taikajuoma)ostettuItem;
                            Console.WriteLine($"\nOstit taikajuoman: {ostettuItem.GetNimi()}\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nTuote on loppunut tai sinulla ei ole tarpeeksi kultaa.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nValitse 1 tai 2.\n");
                }
            }
        }

        static Vihollis ValitseSatunnainenVihollinen(Random random, int day)
        {
            Vihollis[] viholliset;

            if (day % 2 == 1)
            {
                viholliset = new Vihollis[]
                {
                    new Vihollis("Kultainen ritari", 4, 50),
                    new Vihollis("Enkeli", 8, 20),
                    new Vihollis("Megalodaunt", 5, 30)
                };
            }
            else
            {
                viholliset = new Vihollis[]
                {
                    new Vihollis(" Haamu", 4, 10),
                    new Vihollis("Rotta", 6, 7),
                    new Vihollis("Ilkeä Kissa", 4, 10)
                };
            }

            int indeksi = random.Next(viholliset.Length);
            return viholliset[indeksi];
        }
    }
}
