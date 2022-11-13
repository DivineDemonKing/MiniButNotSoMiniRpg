using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniButNotSoMiniRpg
{
   
       
    
    class Game
    {
        public string BotName(int numberName)
        {
            string botName;
            switch (numberName)
            {
                case 1:
                    botName = "Агенты_Габена";
                    break;
                case 2:
                    botName = "Не_Любители_чая";
                    break;
                case 3:
                    botName = "Будущие_Хокаге";
                    break;
                case 4:
                    botName = "Рандомный_сброд";
                    break;
                case 5:
                    botName = "Коллекционеры_Кружек_Из_Макдональдса";
                    break;
                case 6:
                    botName = "Любители_Хаков";
                    break;
                case 7:
                    botName = "Goto_В_Коде";
                    break;
                default:
                    botName = "Хакер.";
                    break;
            }
            return botName;
        }
        int StringToInt()
        {
            bool success = false;
            int tempInt = 0;
            string input;
            while (!success)
            {
                input = Console.ReadLine();
                success = int.TryParse(input, out tempInt);
                if (!success)
                {
                    Console.WriteLine("Ошибка, это не число");
                }
            }
            return tempInt;
        }
        void BattleGround()
        {
            int top = 18;
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine(" ~      ~   ~   ~   ~   ~  ~");
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine("          ~        ~      ~ ");
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine("     ~~~      ~~~     ~~~   ");
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine("  ~  ~~~      ~~~     ~~~   ");
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine("     ~~~      ~~~     ~~~   ");
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine("  ~       ~     ~         ~ ");
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine("                   ~    ~   ");
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine("  ~        ~        ~       ");
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine("          ~   o   ~     ~   ");
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine("   ~  o      /О\\      o    ");
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine("     /О\\     ~~~     /О\\  ");
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine("  ~  ~~~    ~     ~  ~~~    ");
            Console.SetCursorPosition(55, top); top++;
            Console.WriteLine("          ~    ~    ~      ~");
        }
        public void PlayGame()
        {
            Console.Write("Придумай название своей команды: ");
            Team heroTeam = new Team();
            Team enemyTeam = new Team();

            HeroContent heroContent = new HeroContent();
            List<HeroContent> heroContentList = heroContent.TotalHeroes();

            //То количество героев которое будет у вашей/вражеской команды

            heroTeam.SetHeroesCount(3);
            enemyTeam.SetHeroesCount(3);

            //Имя вашей команды

            heroTeam.TeamName = Console.ReadLine();
     
            Random randomGenerator = new Random();

            Console.WriteLine($"Выберите {heroTeam.HeroesCount} героев, которые отправятся в путешествие");

            for (int i = 0; i < heroContentList.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {heroContentList[i].Name}");
            }

            //Игрок выбирает себе команду

            List<int> heroesIndex = new List<int>();
            int tempInt = 0;

            string input;

            while (heroesIndex.Count < heroTeam.HeroesCount)
            {
                input = Console.ReadLine();
                int.TryParse(input, out tempInt);
                //отнимаю от tempInt'а 1 потому что иначе при вводе например (если у нас 4 героя) 4, то будет выход индекса за пределами диапазона
                tempInt--;

                while (heroesIndex.Contains(tempInt))
                {
                    input = Console.ReadLine();
                    int.TryParse(input, out tempInt);
                    tempInt--;
                }

                heroesIndex.Add(tempInt);
            }

            for (int i = 0; i < heroesIndex.Count; i++)
            {
                Console.WriteLine(heroContentList[heroesIndex[i]]);
            }

            List<HeroContent> hero = heroTeam.CreateHeroes(heroesIndex);
            heroesIndex.Clear();

          

            //Боту создается случайная команда

            while (heroesIndex.Count < enemyTeam.HeroesCount)
            {
                // Рандом классов идет от 1 до количества героев которые заданы в HeroContent.TotalHeroes.totalHeroes + 1
                tempInt = randomGenerator.Next(0, heroContentList.Count);

                while (heroesIndex.Contains(tempInt))
                {
                    tempInt = randomGenerator.Next(0, heroContentList.Count);
                }

                heroesIndex.Add(tempInt);
            }


            List<HeroContent> enemy = enemyTeam.CreateHeroes(heroesIndex);

            Console.Clear();
            int botTeamNameIndex = randomGenerator.Next(1, 8);
            string botTeamName = BotName(botTeamNameIndex);
            enemyTeam.TeamName = botTeamName;

            Console.WriteLine("Вы забрели на туманную поляну. Тут настолько туманно, что вы даже не можете увидеть своих ног");
            Console.WriteLine("Хорошо, что вы можете чувствовать своих напарников");
            Console.ReadLine();
            Console.WriteLine($"Вдруг вы ощущаете злое присутствие, на вас напали {botTeamName}");
            Console.WriteLine("К сожалению, из-за тумана вы не можете их видить, но прекрасно ощущаете их присутствие");
            Console.ReadLine();
            Console.Clear();

            //Поле боя
            BattleGround();

            Console.SetCursorPosition(0, 0);

            //Таблица с характеристиками персонажа

            Console.WriteLine("Ваша команда:");
            heroTeam.heroesStats(hero);
            Console.WriteLine();
            Console.SetCursorPosition(55,0);
            Console.WriteLine("Не ваша команда");
            int tempRef = 1;
            enemyTeam.heroesStatsSetCursor(enemy, 55, ref tempRef);
            Console.WriteLine();

            //Начинается бой

            //Не использую 1 переменную attaker и temp т.к В один ход атакуют обе стороны
            //И если пытаться перезаписать одну из переменных потеряется её прошло значение

            int attaker;
            int botAttaker;

            string temp;

            int target;
            int botTarget;

            while (heroTeam.AmountDead(hero) < 3 && enemyTeam.AmountDead(enemy) < 3)
            {
                //Игрок наносит удар
                Console.WriteLine("Кем атаковать");

                temp = Console.ReadLine();
                int.TryParse(temp, out attaker);

                //Если персонаж которого выбрали мертв
                if (hero[attaker-1].Dead == true)
                {
                    Console.WriteLine("Этот персонаж мертв");
                    temp = Console.ReadLine();
                    int.TryParse(temp, out attaker);
                }

                Console.WriteLine("Кого атаковать");

                temp = Console.ReadLine();
                int.TryParse(temp, out target);

                //Если персонаж которого выбрали мертв
                if (enemy[target-1].Dead == true)
                {
                    Console.WriteLine("Этот персонаж мертв");
                    temp = Console.ReadLine();
                    int.TryParse(temp, out target);
                }             

                //Компьютер наносит удар

                botAttaker = randomGenerator.Next(1, 4);

                while (enemy[botAttaker - 1].Dead == true)
                {
                    botAttaker = randomGenerator.Next(1, 4);
                }

                    botTarget = randomGenerator.Next(1, 4);

                while (hero[botTarget - 1].Dead == true)
                {
                    botTarget = randomGenerator.Next(1, 4);
                }

                //Производиться нанесение урона

                heroTeam.DealDamage(enemy[target - 1], hero[attaker - 1].Damage);

                enemyTeam.DealDamage(hero[botTarget - 1], enemy[botAttaker - 1].Damage);

                if (enemy[target - 1].Dead == true)
                {
                    Console.WriteLine($"Вражеский {enemy[botTarget - 1].Name} {enemy[botTarget - 1].Hp} Умер");
                }

                if (hero[botTarget - 1].Dead == true)
                {
                    Console.WriteLine($"Ваш {hero[target-1].Name} Мертв");
                }

                Console.SetCursorPosition(0, 0);

                Console.WriteLine("Ваша команда:");
                heroTeam.heroesStats(hero);
                Console.WriteLine();
                Console.SetCursorPosition(55, 0);
                Console.WriteLine("Не ваша команда");
                tempRef = 1;
                enemyTeam.heroesStatsSetCursor(enemy, 55, ref tempRef);
                Console.SetCursorPosition(0, 17);
                Console.WriteLine("                                         ");
                Console.WriteLine("                                         ");
                Console.WriteLine("                                         ");
                Console.WriteLine("                                         ");
                Console.WriteLine("                                         ");
                Console.WriteLine("                                         ");
                Console.WriteLine("                                         ");
                Console.WriteLine("                                         ");
                Console.WriteLine("                                         ");

                Console.SetCursorPosition(0, 17);
            }
            
            if (heroTeam.AmountDead(hero) >= 3 && enemyTeam.AmountDead(enemy) >3)
            {
                Console.WriteLine("Ничья");
            }
            else if (heroTeam.AmountDead(hero) < 3)
            {
                Console.WriteLine("Вы победили  ");
            }
            else if (enemyTeam.AmountDead(enemy) < 3)
            {
                Console.WriteLine("Враг победил");
            }
                

        }
    } 
} 
