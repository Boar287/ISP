﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    abstract class Player
    {
        protected int _BacisHealth;
        protected double _Armor;
        protected int _Health;
        protected int _EvadeChance;
        protected int _Capacity = 4;
        public string ClassName { get; protected set; }

        public int Invise { get; set; }
        public int Stun { get; set; }
        public int AbilityCD { get; set; }
        public int PotionCD { get; set; }
        public int BuffCD { get; set; }
        public void ReduceCD()
        {
            if (PotionCD != 0)
                PotionCD--;
            if (AbilityCD != 0)
                AbilityCD--;
            if (Stun != 0)
                Stun--;
            if (Invise != 0)
                Invise--;
            if (BuffCD != 0)
                BuffCD--;
        }

        public List<Potion>Invenotry = new List<Potion>();
        public void ShowInventory()
        {
            if (Invenotry.Count == 0)
            {
                Console.WriteLine("Empty");
                return;
            }
            for(int i=0;i<Invenotry.Count;i++)
            {
                Console.Write((i+1+")")+Invenotry[i].Name+"  ");
            }
            Console.WriteLine(); 
        }
        public Weapon UsingWeapon { get; set; }
        public bool UsingShield = false;
        public int Damage 
        {
            get { return UsingWeapon.Damage; }
        }
        public int BasicHealth { get { return _BacisHealth; } }
        public virtual void DealDamage(Enemy target)
        {
            Random rand = new Random();
            int RandFactor = rand.Next(1,UsingWeapon.RandFactor);
            double DMGBuffModificator;
            if (BuffCD == 0)
                DMGBuffModificator = 1;
            else
                DMGBuffModificator = 1.3;
            if ((rand.Next(1, 100) <= UsingWeapon.MissChance)||(rand.Next(1,100)<=target.EvasionChance))
            {
                Console.WriteLine("You MISSED!");
                target.Health -= 0;
            }
            else
            {
                if (rand.Next(1, 100) <= UsingWeapon.CritChance)
                {
                    Console.WriteLine($"CRIT! -{Convert.ToInt32(((UsingWeapon.Damage + RandFactor)* DMGBuffModificator * 2) + ((UsingWeapon.Damage + RandFactor)* DMGBuffModificator * 2 * target.Armor / 1000))} ({Convert.ToInt32((UsingWeapon.Damage + RandFactor)* DMGBuffModificator * 2 * target.Armor / 1000)} Blocked)");
                    target.Health -= Convert.ToInt32((((UsingWeapon.Damage + RandFactor)* DMGBuffModificator * 2) + ((UsingWeapon.Damage + RandFactor)* DMGBuffModificator * 2 * target.Armor / 1000)));
                }
                else
                {
                    Console.WriteLine($"Hit! -{Convert.ToInt32((UsingWeapon.Damage + RandFactor)* DMGBuffModificator + target.Armor / 1000 * ((UsingWeapon.Damage + RandFactor)* DMGBuffModificator))} ({Convert.ToInt32(target.Armor / 1000 * ((UsingWeapon.Damage + RandFactor)* DMGBuffModificator))} Blocked)");
                    target.Health -= Convert.ToInt32((((UsingWeapon.Damage + RandFactor))* DMGBuffModificator + (target.Armor / 1000 * ((UsingWeapon.Damage + RandFactor)* DMGBuffModificator))));
                }
            }
        }

        public double Armor 
        { 
            get { return _Armor; }
            private set { _Armor = value; }
        }
        public int Health 
        {
            get { return _Health; } 
            set { _Health = value; }
        }
        public int EvadeChance { get { return _EvadeChance; } }
        public int Capacity { get { return _Capacity; } } 
        public void ReduceCapacity() { _Capacity--; }
        public void RenewCapacity() 
        {
            Invenotry.Clear();
            if ((UsingWeapon.OneHand == true) && (UsingShield == false))
                _Capacity = 3;
            else if ((UsingWeapon.OneHand == true) && (UsingShield == true))
                _Capacity = 2;
            else if (UsingWeapon.OneHand == false)
                _Capacity = 2;
        }
        public void ChangeArmor(int Number) { _Health += Number * _Health; }
        public abstract void PlayerInfo();
        public abstract void UniqueAbility(Enemy target);
        public static void GetClassesInfo()
        {
            List<Player> Classes = new List<Player>() { new Mage(), new Warrior(), new Hunter(), new Rogue() };
            for(int i=0;i<Classes.Count;i++)
            {
                Classes[i].PlayerInfo();
            }
        }
    }

    class Mage : Player
    {
        public override void PlayerInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Mage's info:");
            Console.ResetColor();
            Console.WriteLine($"\tHealth:{_Health}");
            Console.WriteLine($"\tArmor:{_Armor}");
            Console.WriteLine($"\tEvade Chance:{_EvadeChance}%");
            Console.WriteLine("Abilities");
            Console.WriteLine("\tActive:<Pyroblast>-deals from 76 to 103 damage (once per 2 turnes)");
            Console.WriteLine("\tPassive:<Arcane Intellect>-Healing effect can overheal you");
            Console.WriteLine("-------------------------------------------------");
        }

        public override void UniqueAbility(Enemy target)
        {
            Random rand=new Random();
            int Damage = rand.Next(76, 103);
            target.Health -=Damage;
            Console.WriteLine($"You have casted Pyroblast -{Damage}");
            AbilityCD = 2;
        }

        public Mage()
        {
            _Armor = 80;
            _Health = _BacisHealth=200;
            _EvadeChance = 25;
            ClassName = "Mage";
        }
    }

    class Rogue : Player
    {
        public override void PlayerInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Rogue's info:");
            Console.ResetColor();
            Console.WriteLine($"\tHealth:{_Health}");
            Console.WriteLine($"\tArmor:{_Armor}");
            Console.WriteLine($"\tEvade Chance:{_EvadeChance}%");
            Console.WriteLine("Abilities");
            Console.WriteLine("\tActive:<Stealth>-you can vanish for 1 turn (once per 3 turnes)");
            Console.WriteLine("\tPassive:<Vendetta>-your critical strikes deal 125% more damage (base multiplier-100%)");
            Console.WriteLine("-------------------------------------------------");
        }

        public override void DealDamage(Enemy target)
        {
            Random rand = new Random();
            int RandFactor = rand.Next(1, UsingWeapon.RandFactor);
            double DMGBuffModificator;
            if (BuffCD == 0)
                DMGBuffModificator = 1;
            else
                DMGBuffModificator = 1.3;
            if ((rand.Next(1, 100) <= UsingWeapon.MissChance) || (rand.Next(1, 100) <= target.EvasionChance))
            {
                Console.WriteLine("You MISSED!");
                target.Health -= 0;
            }
            else
            {
                if (rand.Next(1, 100) <= UsingWeapon.CritChance)
                {
                    Console.WriteLine($"CRIT! -{Convert.ToInt32(((UsingWeapon.Damage + RandFactor)* DMGBuffModificator * 2.25) + ((UsingWeapon.Damage + RandFactor)* DMGBuffModificator * 2.25 * target.Armor / 1000))} ({Convert.ToInt32((UsingWeapon.Damage + RandFactor)* DMGBuffModificator * 2.25 * target.Armor / 1000)} Blocked)");
                    target.Health -= Convert.ToInt32((((UsingWeapon.Damage + RandFactor)* DMGBuffModificator * 2.25) + ((UsingWeapon.Damage + RandFactor)* DMGBuffModificator * 2.25 * target.Armor / 1000)));
                }
                else
                {
                    Console.WriteLine($"Hit! -{Convert.ToInt32((UsingWeapon.Damage + RandFactor)* DMGBuffModificator + target.Armor / 1000 * ((UsingWeapon.Damage + RandFactor)* DMGBuffModificator))} ({Convert.ToInt32(target.Armor / 1000 * ((UsingWeapon.Damage + RandFactor)* DMGBuffModificator))} Blocked)");
                    target.Health -= Convert.ToInt32(((UsingWeapon.Damage + RandFactor)* DMGBuffModificator + (target.Armor / 1000 * ((UsingWeapon.Damage + RandFactor)* DMGBuffModificator))));
                }
            }
        }

        public override void UniqueAbility(Enemy target)
        {
            Console.WriteLine("You have entered invisibility, now enemy can't hit you");
            AbilityCD = 3;
            Invise = 2;
        }

        public Rogue()
        {
            _Armor = 120;
            _Health= _BacisHealth = 280;
            _EvadeChance = 25;
            ClassName = "Rogue";
        }
    }

    class Hunter : Player
    {
        private int PetDamage = 25;
        private int PetCritChance = 15;
        private int PetMissChance = 15;
        public override void PlayerInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hunter's info:");
            Console.ResetColor();
            Console.WriteLine($"\tHealth:{_Health}");
            Console.WriteLine($"\tArmor:{_Armor}");
            Console.WriteLine($"\tEvade Chance:{_EvadeChance}%");
            Console.WriteLine("Abilities");
            Console.WriteLine("\tPassive:<Experienced trapper>-You have a pet which helps you duirng the battle");
            Console.WriteLine("Pet's info:");
            Console.WriteLine($"\tDamage:{PetDamage}-{PetDamage+7}");
            Console.WriteLine($"\tCritical Chance:{PetCritChance}%");
            Console.WriteLine($"\tMiss Chance:{PetMissChance}%");
            Console.WriteLine("-------------------------------------------------");
        }

        public override void DealDamage(Enemy target)
        {
            base.DealDamage(target);
            PetDealDamage(target);
        }

        public void PetDealDamage(Enemy target)
        {
            Random rand = new Random();
            int RandFactor = rand.Next(1, 7);
            if ((rand.Next(1, 100) <= PetMissChance) || (rand.Next(1, 100) <= target.EvasionChance))
            {
                Console.WriteLine("Your pet MISSED!");
                target.Health -= 0;
            }
            else
            {
                if (rand.Next(1, 100) <= PetCritChance)
                {
                    Console.WriteLine($"Pet CRIT! -{Convert.ToInt32(((PetDamage + RandFactor) * 1.5) + ((UsingWeapon.Damage + RandFactor) * 1.5 * target.Armor / 1000))} ({Convert.ToInt32((UsingWeapon.Damage + RandFactor) * 1.5 * target.Armor / 1000)} Blocked)");
                    target.Health -= Convert.ToInt32((((UsingWeapon.Damage + RandFactor) * 1.5) + ((UsingWeapon.Damage + RandFactor) * 1.5 * target.Armor / 1000)));
                }
                else
                {
                    Console.WriteLine($"Pet Hit! -{Convert.ToInt32(UsingWeapon.Damage + RandFactor + target.Armor / 1000 * (UsingWeapon.Damage + RandFactor))} ({Convert.ToInt32(target.Armor / 1000 * (UsingWeapon.Damage + RandFactor))} Blocked)");
                    target.Health -= Convert.ToInt32(((UsingWeapon.Damage + RandFactor) + (target.Armor / 1000 * (UsingWeapon.Damage + RandFactor))));
                }
            }
        }

        public override void UniqueAbility(Enemy target)
        {
           
        }

        public Hunter()
        {
            _Armor = 160;
            _Health= _BacisHealth = 300;
            _EvadeChance = 18;
        }
    }

    class Warrior : Player
    {
        public override void PlayerInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warrior's info:");
            Console.ResetColor();
            Console.WriteLine($"\tHealth:{_Health}");
            Console.WriteLine($"\tArmor:{_Armor}");
            Console.WriteLine($"\tEvade Chance:{_EvadeChance}%");
            Console.WriteLine("Abilities");
            Console.WriteLine("\tActive:<Hilt strike>-stuns enemy for 1 turn (once per 3 turnes)");
            Console.WriteLine("\tPassive:<Iron skin>-has 50% chance to avoid stun");
            Console.WriteLine("-------------------------------------------------");
        }

        public override void UniqueAbility(Enemy target)
        {
            if ((target.EnemyName == "Goblin") && (target.EnabledAbility==true))
            {
                Console.WriteLine("This type of enemy has immune to stuns");
                AbilityCD = 3;
            }
            else
            {
                AbilityCD = 3;
                target.Stun = 2;
            }
        }

        public Warrior()
        {
            _Armor = 200;
            _Health=_BacisHealth= 330;
            _EvadeChance = 10;
            ClassName = "Warrior";
        }
    }

}
