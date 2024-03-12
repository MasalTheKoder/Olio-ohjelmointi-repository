using System;

namespace Peli
{
    abstract class Item
    {
        protected string nimi;
        protected int hinta; 

        public string GetNimi()
        {
            return nimi;
        }

        public int Hinta { get { return hinta; } } 
    }

    class Ase : Item
    {
        private int vahinko;

        public Ase(string nimi, int vahinko, int hinta) 
        {
            this.nimi = nimi;
            this.vahinko = vahinko;
            this.hinta = hinta; 
        }

        public int Vahinko { get { return vahinko; } }
    }

    class Haarniska : Item
    {
        private int suojelu;

        public Haarniska(string nimi, int suojelu, int hinta) 
        {
            this.nimi = nimi;
            this.suojelu = suojelu;
            this.hinta = hinta; 
        }

        public int Suojelu { get { return suojelu; } }
    }

    class Taikajuoma : Item
    {
        private int parannus;

        public Taikajuoma(string nimi, int parannus, int hinta) 
        {
            this.nimi = nimi;
            this.parannus = parannus;
            this.hinta = hinta; 
        }

        public int Parantaa()
        {
            return parannus;
        }
    }
}
