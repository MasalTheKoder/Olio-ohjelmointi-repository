using System;

namespace RitariPeli
{
    public class Potion : Item
    {
        public int HealAmount { get; set; }

        public Potion(string name, int price, int healAmount)
            : base(name, price)
        {
            HealAmount = healAmount;
        }

        public override void Use(Knight knight)
        {
            knight.Heal(HealAmount);
            Console.WriteLine($"{knight.Name} käytti {Name} ja healasi {HealAmount} HP!");
        }
    }
}
