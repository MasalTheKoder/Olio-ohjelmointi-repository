using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peli
{
    class Ritari
    {
        private string nimi;
        private int voima;
        private int terveys;
        private Ase ase;
        private Haarniska haarniska;
        private Taikajuoma taikajuoma;

        public Ritari(string nimi, int voima, int terveys)
        {
            this.nimi = nimi;
            this.voima = voima;
            this.terveys = terveys;
        }

        public string Nimi { get { return nimi; } }
        public int Voima { get { return voima; } }
        public int Terveys { get { return terveys; } }
        public Ase Ase { get { return ase; } set { ase = value; } }
        public Haarniska Haarniska { get { return haarniska; } set { haarniska = value; } }
        public Taikajuoma Taikajuoma { get { return taikajuoma; } set { taikajuoma = value; } }

        public void OtaVahinkoa(int vahinko)
        {
            terveys -= vahinko;
            if (terveys < 0)
            {
                terveys = 0;
            }
        }

        public void KäytäTaikajuoma()
        {
            if (taikajuoma != null)
            {
                terveys += taikajuoma.Parantaa();
                taikajuoma = null;
            }
        }
    }
}
