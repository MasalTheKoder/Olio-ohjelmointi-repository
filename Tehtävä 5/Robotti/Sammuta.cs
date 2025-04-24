using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotti
{
    class Sammuta : RobottiKäsky
    {
        public override void Suorita(Robotti kohde)
        {
            kohde.OnKäynnissä = false;
        }
    }
}