using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniButNotSoMiniRpg
{
    class Thief : HeroContent
    {
        public Thief()
        {
            Name = "Вор";
            Hp = 500;
            Damage = 150;
            Armor = 0.35;
            Dead = false;
        }
    }
}
