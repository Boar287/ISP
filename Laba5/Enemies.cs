using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    abstract class Enemy
    {
        protected int _Damage;
        protected double _Armor;
        protected int _EvasionChance;
        protected int _MissChance;
        protected int _CritChance;
        protected int _Health;
        public string EnemyName { get; protected set; }
        public bool EnabledAbility { get; protected set; }
        public int AbilityCD { get; protected set; }
        public int Stun { get; set; }
        public void ReduceCD()
        {
            if (Stun != 0)
                Stun--;
            if (AbilityCD != 0)
                AbilityCD--;

        }

        public int Damage { get { return _Damage; } }
        public double Armor { get { return _Armor; } }
        public int EvasionChance { get { return _EvasionChance; } }
        public int MissChance { get { return _MissChance; } }
        public int CritChance { get { return _CritChance; } }
        public int Health
        { 
            get { return _Health; } 
            set { _Health = value; }
        }

        public abstract void ShowInfo();
        public abstract void UniqueEffect(Player player);

        public void DealDamage(Player target)
        {
            Random rand = new Random();
            int RandFactor = rand.Next(1, 15);
            if (target.UsingShield == false)
            {
                if ((rand.Next(1, 100) <= MissChance) || (rand.Next(1, 100) <= target.EvadeChance))
                {
                    Console.WriteLine("Enemy MISS!");
                    target.Health -= 0;
                }
                else
                {
                    if (rand.Next(1, 100) <= CritChance)
                    {
                        Console.WriteLine($"Enemy CRIT! -{Convert.ToInt32(((Damage + RandFactor) * 2) + ((Damage + RandFactor) * 2 * target.Armor / 1000))} ({Convert.ToInt32((Damage + RandFactor) * 2 * target.Armor / 1000)} Blocked)");
                        target.Health -= Convert.ToInt32((((Damage + RandFactor) * 2) + ((Damage + RandFactor) * 2 * target.Armor / 1000)));
                    }
                    else
                    {
                        Console.WriteLine($"Enemy hit! -{Convert.ToInt32(Damage + RandFactor + target.Armor / 1000 * (Damage + RandFactor))} ({Convert.ToInt32(target.Armor / 1000 * (Damage + RandFactor))} Blocked)");
                        target.Health -= Convert.ToInt32(((Damage + RandFactor) + (target.Armor / 1000 * (Damage + RandFactor))));
                    }
                }
            }
            else if(target.UsingShield==true)
            {
                if ((rand.Next(1, 100) <= MissChance) || (rand.Next(1, 100) <= target.EvadeChance))
                {
                    Console.WriteLine("Enemy MISS!");
                    target.Health -= 0;
                }
                else if(rand.Next(1,100)<=10)
                {
                    Console.WriteLine("BLOCK!");
                    target.Health -= 0;
                }
                else
                {
                    if (rand.Next(1, 100) <= CritChance)
                    {
                        Console.WriteLine($"Enemy CRIT! -{Convert.ToInt32(((Damage + RandFactor) * 2) + ((Damage + RandFactor) * 2 * target.Armor*2 / 1000))} ({Convert.ToInt32((Damage + RandFactor) * 2 * target.Armor*2 / 1000)} Blocked)");
                        target.Health -= Convert.ToInt32((((Damage + RandFactor) * 2) + ((Damage + RandFactor) * 2 * target.Armor / 1000)));
                    }
                    else
                    {
                        Console.WriteLine($"Enemy hit! -{Convert.ToInt32(Damage + RandFactor + target.Armor*2 / 1000 * (Damage + RandFactor))} ({Convert.ToInt32(target.Armor*2 / 1000 * (Damage + RandFactor))} Blocked)");
                        target.Health -= Convert.ToInt32(((Damage + RandFactor) + (target.Armor*2 / 1000 * (Damage + RandFactor))));
                    }
                }
            }
        }

        public static void GetEnemiesInfo(DifficultyLevel difficultyLevel = DifficultyLevel.Easy)
        {
            List<Enemy> Enemies = new List<Enemy>() { new Orc(difficultyLevel), new Gnome(difficultyLevel), new Goblin(difficultyLevel) };
            for(int i=0;i<Enemies.Count;i++)
            {
                Enemies[i].ShowInfo();
            }
        }
        public Enemy(DifficultyLevel difficultyLevel)
        {
            if (difficultyLevel == DifficultyLevel.Hard)
                EnabledAbility = true;
            else
                EnabledAbility = false;
        }
    }

    class Gnome:Enemy
    {
        public Gnome(DifficultyLevel difficultyLevel=DifficultyLevel.Easy):base(difficultyLevel)
        {
            EnemyName = "Gnome";
            _Damage = 33;
            _Damage += Convert.ToInt32((_Damage * (int)difficultyLevel) / 100);
            _Health = 300;
            _Health += Convert.ToInt32((_Health * (int)difficultyLevel) / 100);
            _EvasionChance = 20;
            _CritChance = 25;
            _Armor = 180;
            _Armor += Convert.ToInt32((_Armor * (int)difficultyLevel) / 100);
            _MissChance = 10;
        }

        public override void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Gnome's info:");
            Console.ResetColor();
            Console.WriteLine($"\tDamage:{_Damage}");
            Console.WriteLine($"\tHealth:{_Health}");
            Console.WriteLine($"\tEvasion Chance:{_EvasionChance}%");
            Console.WriteLine($"\tCritical Chance:{_CritChance}%");
            Console.WriteLine($"\tMiss Chance:{_MissChance}%");
            Console.WriteLine($"\tArmor:{_Armor}");
            Console.WriteLine("Ability:");
            Console.WriteLine("\tPassive<Dexterous hands>-takes one potion from your backpack (Once per battle)");
            Console.WriteLine("-------------------------------------------------");
        }

        public override void UniqueEffect(Player player)
        {
            AbilityCD = 9999;
            Console.WriteLine("Gnome steals a potion!");
            Random rand=new Random();
            player.Invenotry.RemoveAt(rand.Next(1, player.Invenotry.Count));

        }
    }

    class Orc : Enemy
    {
        public Orc(DifficultyLevel difficultyLevel = DifficultyLevel.Easy) : base(difficultyLevel)
        {
            EnemyName = "Orc";
            _Damage = 48;
            _Damage += Convert.ToInt32((_Damage * (int)difficultyLevel) / 100);
            _Health = 350;
            _Health += Convert.ToInt32((_Health * (int)difficultyLevel) / 100);
            _EvasionChance = 10;
            _CritChance = 12;
            _Armor = 350;
            _Armor += Convert.ToInt32((_Armor * (int)difficultyLevel) / 100);
            _MissChance = 27;
        }

        public override void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Orc's info:");
            Console.ResetColor();
            Console.WriteLine($"\tDamage:{_Damage}");
            Console.WriteLine($"\tHealth:{_Health}");
            Console.WriteLine($"\tEvasion Chance:{_EvasionChance}%");
            Console.WriteLine($"\tCritical Chance:{_CritChance}%");
            Console.WriteLine($"\tMiss Chance:{_MissChance}%");
            Console.WriteLine($"\tArmor:{_Armor}");
            Console.WriteLine("Ability:");
            Console.WriteLine("\tActive<Thunder tread>-stuns you for 1 tures (Once per 4 turnes)");
            Console.WriteLine("-------------------------------------------------");
        }

        public override void UniqueEffect(Player player)
        {
            if (player.ClassName == "Warrior")
            {
                Random rand = new Random();
                int StunChance = rand.Next(1, 2);
                if (StunChance == 1)
                {
                    Console.WriteLine("Enemy stuns you");
                    player.Stun = 2;
                }
                else
                    Console.WriteLine("Enemy tried to stun you");

            }
            else
            {
                Console.WriteLine("Enemy stuns you!");
                player.Stun = 2;
            }
            AbilityCD = 4;
        }
    }

    class Goblin : Enemy
    {
        public Goblin(DifficultyLevel difficultyLevel = DifficultyLevel.Easy) : base(difficultyLevel)
        {
            EnemyName = "Goblin";
            _Damage = 24;
            _Damage += Convert.ToInt32((_Damage * (int)difficultyLevel) / 100);
            _Health = 250;
            _Health+= Convert.ToInt32((_Health * (int)difficultyLevel) / 100);
            _EvasionChance = 27;
            _CritChance = 30;
            _Armor = 150;
            _Armor+= Convert.ToInt32((_Armor * (int)difficultyLevel) / 100);
            _MissChance = 5;

        }

        public override void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Goblin's info:");
            Console.ResetColor();
            Console.WriteLine($"\tDamage:{_Damage}");
            Console.WriteLine($"\tHealth:{_Health}");
            Console.WriteLine($"\tEvasion Chance:{_EvasionChance}%");
            Console.WriteLine($"\tCritical Chance:{_CritChance}%");
            Console.WriteLine($"\tMiss Chance:{_MissChance}%");
            Console.WriteLine($"\tArmor:{_Armor}");
            Console.WriteLine("Ability:");
            Console.WriteLine("\tPassive<Vigorous>-Has imune to stuns");
            Console.WriteLine("-------------------------------------------------");
        }

        public override void UniqueEffect(Player player) { AbilityCD = 9999; DealDamage(player); }
    }
}
