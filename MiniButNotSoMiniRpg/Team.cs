using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniButNotSoMiniRpg
{
    class Team
    {
        public int HeroesCount { get; private set; }
        public string TeamName { get; set; }

        public void SetHeroesCount(int amount)
        {
            HeroesCount = amount;
        }

        public int AmountDead(List<HeroContent> heroList)
        {
            int amountDead = 0;
            for (int i = 0; i < HeroesCount; i++)
            {
                if (heroList[i].Dead == true)
                {
                    amountDead++;
                }
            }
            return amountDead;
        }

        public void DealDamage(HeroContent heroTarget, int damage)
        {
            heroTarget.DamageTake(damage, heroTarget);
        }

        List<HeroContent> hero = new List<HeroContent>();

        public List<HeroContent> CreateHeroes(List<int> heroesIndex)
        {
            HeroContent heroContent = new HeroContent();
            List<HeroContent> heroContentList = heroContent.TotalHeroes();

            for (int i = 0; i < heroesIndex.Count; i++)
            {
                hero.Add(heroContentList[heroesIndex[i]]);
            }

            return hero;
        }
        public void heroesStats(List<HeroContent> heroes)
        {
            for (int i = 0; i < HeroesCount; i++)
            {
                 heroes[i].Stats();
            }          
        }

        public void heroesStatsSetCursor(List<HeroContent> heroes, int left, ref int top)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine($"'{TeamName}'");
            for (int i = 0; i < HeroesCount; i++)
            {
                heroes[i].StatsSetCursor(left, ref top);
            }
        }

        //Возможно будет доделано в будущем

        public void HeroJoin()
        {
            //метод если по пути (или в бою) к вам присоедениться герой
        }
        public void EnemyJoin()
        {
            //метод если во время боя к врагу присоеденится персонаж
        }
       
    }
}
