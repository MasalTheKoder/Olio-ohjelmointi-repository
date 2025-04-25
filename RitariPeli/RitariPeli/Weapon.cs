using System;


namespace RitariPeli
{
    public class Weapon : Item
    {
        public int AttackBonus { get; set; }

        public Weapon(string name, int price, int attackBonus)
            : base(name, price)
        {
            AttackBonus = attackBonus;
        }

        public override void Use(Knight knight)
        {
            knight.EquippedWeapon = this;
            Console.WriteLine($"{knight.Name} Equippasi: {Name} (+{AttackBonus} attack)");
        }
    }
}
