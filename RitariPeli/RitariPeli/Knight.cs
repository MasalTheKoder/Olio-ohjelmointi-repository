using System;
using System.Collections.Generic;

namespace RitariPeli
{
    public class Knight
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; } = 100;
        public int CurrentHealth { get; set; }
        public int Gold { get; set; } = 100;

        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }

        public List<Potion> Potions { get; set; }

        public Knight(string name)
        {
            Name = name;
            CurrentHealth = MaxHealth;
            Potions = new List<Potion>();
        }

        public void Heal(int amount)
        {
            CurrentHealth += amount;
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Nimi: {Name}");
            Console.WriteLine($"HP: {CurrentHealth}/{MaxHealth}");
            Console.WriteLine($"Kulta: {Gold} kultaa");
            Console.WriteLine($"Ase: {(EquippedWeapon != null ? EquippedWeapon.Name : "Ei ole")}");
            Console.WriteLine($"Haarniska: {(EquippedArmor != null ? EquippedArmor.Name : "Ei ole")}");
            Console.WriteLine($"Potions: {Potions.Count} kpl");
        }
    }
}
