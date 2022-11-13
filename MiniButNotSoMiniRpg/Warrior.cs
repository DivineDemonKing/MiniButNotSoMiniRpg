using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniButNotSoMiniRpg
{
    class Warrior : HeroContent
    {
        public Warrior()
        {
            Name = "Воин";
            Hp = 700;
            Damage = 100;
            Armor = 0.5;
            Dead = false;
        }
    }
}
