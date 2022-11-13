using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniButNotSoMiniRpg
{
    class HeroContent
    {
        public HeroContent()
        {

        }

        public List<HeroContent> TotalHeroes()
        {
            Archer archer = new Archer();
            Warrior warrior = new Warrior();
            FireMage fireMage = new FireMage();
            Thief thief = new Thief();
            Druid druid = new Druid();

            //Тут вы выбираете порядок вывода героев и то, какие герои будут учавствовать в битве

            List<HeroContent> totalHeroes = new List<HeroContent>() {warrior, thief, fireMage, druid, archer };

            return totalHeroes;
        }



        public string Name { get; set; }
        public int Hp { get; set; }
        public int Damage { get; set; }
        public double Armor { get; set; }
        public bool Dead { get; set; }

        public void Stats()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"{Name}");
            if (Hp > 0)
            {
                Console.WriteLine($"Хп: {Hp, -10}");
            }
            else
            {
                Console.WriteLine($"Хп: {Hp} [Мертв]");
            }
            Console.WriteLine($"Процент блокируемого урона: {Armor * 100}%");
            Console.WriteLine($"Урон: {Damage}");
        }
        //StatsSetCursor в процессе доработки
        public void StatsSetCursor(int left, ref int top)
        {
            //Возвращаю top для того что бы каждый цикл в team не прибавлять top
            //Количество строчек который он прибавляет здесь

            Console.SetCursorPosition(left, top); top++;
            Console.WriteLine("------------------------------------------------------");
            Console.SetCursorPosition(left, top); top++;
            Console.WriteLine($"{Name}");
            if (Hp > 0)
            {
                Console.SetCursorPosition(left, top); top++;
                Console.WriteLine($"Хп: {Hp, -10}");
            }
            else
            {
                Console.SetCursorPosition(left, top); top++;
                Console.WriteLine($"Хп: {Hp} [Мёртв]");
            }
            Console.SetCursorPosition(left, top); top++;
            Console.WriteLine($"Процент блокируемого урона: {Armor * 100}%");
            Console.SetCursorPosition(left, top); top++;
            Console.WriteLine($"Урон: {Damage}");
        }

        //Тут нету метода DamageDeal (нанесение урона), т.к
        //Этот метод находится в team и будет вызывать срабатывание метода DamageTake у персонажей

        public void DamageTake(int damageTake, HeroContent heroTarget)
        {
            Hp -= (int)(damageTake * (1 - heroTarget.Armor));
            if (Hp <= 0)
            {               
                Hp = 0;
                Dead = true;
            }
        }
    }
}
