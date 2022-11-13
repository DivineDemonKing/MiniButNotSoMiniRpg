using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniButNotSoMiniRpg
{
    class FireMage : HeroContent
    {
        public FireMage()
        {
            Name = "Маг Огня";
            Hp = 400;
            Damage = 250;
            Armor = 0.15;
            Dead = false;
        }
    }
}
