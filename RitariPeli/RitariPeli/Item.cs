namespace RitariPeli
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public abstract void Use(Knight knight); 
    }
}
