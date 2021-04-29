using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Laba5
{
    abstract class Weapon: IShowInfo
    {
        protected int _Damage;
        protected int _CritChance;
        protected int _MissChance;
        protected bool _OneHand;
        public int RandFactor;
        public string WeaponName { get; protected set; }

        public int Damage { get { return _Damage; } }
        public int CritChance { get { return _CritChance; } }
        public int MissChance { get { return _MissChance; } }
        public bool OneHand { get { return _OneHand; } }

        public abstract void ShowInfo();
        public int CompareTo(IShowInfo other)
        {
            Weapon temp = other as Weapon;
            switch (IShowInfo.Choice)
            {
                case ConsoleKey.D1:
                    if (_Damage < temp._Damage)
                        return 1;
                    else
                        return -1;
                case ConsoleKey.D2:
                    if (WeaponName[0] < temp.WeaponName[0])
                        return -1;
                    else
                        return 1;
                default:
                    return 1;
            }
        }

        public static Weapon[] Weapons = new Weapon[] {new Dagger(),new Fist(),new TwoHandAxe(),new Staff(),new PoleArm(),new Bow() };
    }

    class Dagger : Weapon 
    {
        public override void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Dagger's info:");
            Console.ResetColor();
            Console.WriteLine($"\tDamage:{Damage}-{Damage+RandFactor}");
            Console.WriteLine($"\tCritical chance:{CritChance}%");
            Console.WriteLine($"\tMiss Chance:{MissChance}%");
            Console.WriteLine($"\tIn one hand:{OneHand}");
            Console.WriteLine("Good choice for rogues");
            Console.WriteLine("-------------------------------------------------");
        }

        public Dagger()
        {
            _Damage = 35;
            _CritChance = 25;
            _MissChance = 10;
            RandFactor = 8;
            _OneHand = true;
            WeaponName = "Dagger";
        }
    }

    class Fist : Weapon
    {
        public override void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("First's info:");
            Console.ResetColor();
            Console.WriteLine($"\tDamage:{Damage}-{Damage + RandFactor}");
            Console.WriteLine($"\tCritical chance:{CritChance}%");
            Console.WriteLine($"\tMiss Chance:{MissChance}%");
            Console.WriteLine($"\tIn one hand:{OneHand}");
            Console.WriteLine("Good choice for rogues");
            Console.WriteLine("-------------------------------------------------");
        }

        public Fist()
        {
            _Damage = 44;
            _CritChance = 20;
            _MissChance = 5;
            RandFactor = 9;
            _OneHand = true;
            WeaponName = "Fist";
        }
    }

    class TwoHandAxe : Weapon
    {
        public override void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Two hand axe's info:");
            Console.ResetColor();
            Console.WriteLine($"\tDamage:{Damage}-{Damage + RandFactor}");
            Console.WriteLine($"\tCritical chance:{CritChance}%");
            Console.WriteLine($"\tMiss Chance:{MissChance}%");
            Console.WriteLine($"\tIn one hand:{OneHand}");
            Console.WriteLine("Not bad for warriors");
            Console.WriteLine("-------------------------------------------------");
        }

        public TwoHandAxe()
        {
            _Damage = 66;
            _CritChance = 15;
            _MissChance = 20;
            RandFactor = 15;
            _OneHand = false;
            WeaponName = "TwoHandAxe";
        }
    }

    class Staff : Weapon
    {
        public override void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Staff's info:");
            Console.ResetColor();
            Console.WriteLine($"\tDamage:{Damage}-{Damage + RandFactor}");
            Console.WriteLine($"\tCritical chance:{CritChance}%");
            Console.WriteLine($"\tMiss Chance:{MissChance}%");
            Console.WriteLine($"\tIn one hand:{OneHand}");
            Console.WriteLine("Mostly for mages");
            Console.WriteLine("-------------------------------------------------");
        }

        public Staff()
        {
            _Damage = 71;
            _CritChance = 5;
            _MissChance = 8;
            RandFactor = 16;
            _OneHand = false;
            WeaponName = "Staff";
        }
    }

    class PoleArm : Weapon
    {
        public override void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Polearm's's info:");
            Console.ResetColor();
            Console.WriteLine($"\tDamage:{Damage}-{Damage + RandFactor}");
            Console.WriteLine($"\tCritical chance:{CritChance}%");
            Console.WriteLine($"\tMiss Chance:{MissChance}%");
            Console.WriteLine($"\tIn one hand:{OneHand}");
            Console.WriteLine("Not bad for warriors");
            Console.WriteLine("-------------------------------------------------");
        }

        public PoleArm()
        {
            _Damage = 60;
            _CritChance = 20;
            _MissChance = 10;
            RandFactor = 14;
            _OneHand = false;
            WeaponName = "PoleArm";
        }
    }

    class Bow : Weapon
    {
        public override void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Bow's info:");
            Console.ResetColor();
            Console.WriteLine($"\tDamage:{Damage}-{Damage + RandFactor}");
            Console.WriteLine($"\tCritical chance:{CritChance}%");
            Console.WriteLine($"\tMiss Chance:{MissChance}%");
            Console.WriteLine($"\tIn one hand:{OneHand}");
            Console.WriteLine("You have one extre turn in the beginnig of the fight,only for hunters");
            Console.WriteLine("-------------------------------------------------");
        }

        public Bow()
        {
            _Damage = 43;
            _CritChance = 15;
            _MissChance = 25;
            RandFactor = 15;
            _OneHand = false;
            WeaponName = "Bow";
        }
    }

}
