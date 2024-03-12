using System;

namespace Peli
{
    class Kulta
    {
        public int Määrä { get; private set; }

        public Kulta(int alkuMäärä)
        {
            Määrä = alkuMäärä; 
        }

        public void LisääKultaa(int määrä)
        {
            Määrä += määrä;
        }

        public void VähennäKultaa(int määrä)
        {
            Määrä -= määrä;
        }
    }
}
