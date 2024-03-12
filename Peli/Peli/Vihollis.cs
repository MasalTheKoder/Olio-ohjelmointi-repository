using System;

namespace Peli
{
    class Vihollis
    {
        private string nimi;
        private int voima;
        private int terveys;

        public Vihollis(string nimi, int voima, int terveys)
        {
            this.nimi = nimi;
            this.voima = voima;
            this.terveys = terveys;
        }

        public string Nimi { get { return nimi; } }
        public int Voima { get { return voima; } }
        public int Terveys { get { return terveys; } }

        public void OtaVahinkoa(int vahinko)
        {
            terveys -= vahinko;
            if (terveys < 0)
            {
                terveys = 0;
            }
        }
    }
}
