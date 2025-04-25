using System;


namespace RitariPeli
{
    public class Armor : Item
    {
        public int DefenseBonus { get; set; }

        public Armor(string name, int price, int defenseBonus)
            : base(name, price)
        {
            DefenseBonus = defenseBonus;
        }

        public override void Use(Knight knight)
        {
            knight.EquippedArmor = this;
            Console.WriteLine($"{knight.Name} Equippasi: {Name} (+{DefenseBonus} defense)");
        }
    }
}
