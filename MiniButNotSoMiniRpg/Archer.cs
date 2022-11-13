using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniButNotSoMiniRpg
{
    class Archer : HeroContent
    {
        public Archer()
        {
            Name = "Лучник";
            Hp = 500;
            Damage = 175;
            Armor = 0.25;
            Dead = false;
        } 
    }
}
