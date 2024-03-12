using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peli
{
    class Kauppa
    {
        public List<Item> shopItems;

        public Kauppa()
        {
            shopItems = new List<Item>();
        }

        public void LisääItem(Item item)
        {
            shopItems.Add(item);
        }

        public Item OstaItem(string nimi, Kulta kulta)
        {
            foreach (Item item in shopItems)
            {
                if (item.GetNimi() == nimi && kulta.Määrä >= item.Hinta) 
                {
                    kulta.VähennäKultaa(item.Hinta); 
                    shopItems.Remove(item);
                    return item;
                }
            }
            return null;
        }

        public int GetItemHinta(Item item)
        {
            return item.Hinta;
        }
    }
}
