namespace RitariPeli
{
    public class Enemy
    {
        public string Name { get; set; }
        public int CurrentHealth { get; set; }
        public int AttackPower { get; set; }

        public Enemy(string name, int health, int attackPower)
        {
            Name = name;
            CurrentHealth = health;
            AttackPower = attackPower;
        }
    }
}
