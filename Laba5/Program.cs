using System;

namespace Laba5
{
    enum DifficultyLevel
    {
        Easy = 0,
        Moderate = 20,
        Hard = 25
    }
    class Program
    {
        static void Main(string[] args)
        {
            Introduction();
        }

        static void Introduction()
        {
            Console.WriteLine("This is small console game where you will be offered to choose class, your weapon and some other parts of equipment");
            Console.WriteLine("After that you have to defeat your enemy which will be determined with help of the random");
            Console.WriteLine("During the battle you can your class abilities, potions and simple strikes with help of the weapon\n");
            Console.WriteLine("Press any button to continue or Backspace if you decided not to start");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            switch (consoleKey)
            {
                case ConsoleKey.Backspace:
                    return;
                default:
                    GetPlayerInfo();
                    break;
            }
        }

        static void BattleProcess(Player player,Enemy enemy)
        {
            if(player.UsingWeapon.WeaponName=="Bow")
            {
                BattleInterface(player, enemy);
                PerformPlayerAction(player, enemy);
                Console.Clear();
            }
            while(player.Health>0&&enemy.Health>0)
            {
                BattleInterface(player, enemy);
                PerformPlayerAction(player, enemy);
                PerformEnemyAction(enemy, player);
                player.ReduceCD();
                enemy.ReduceCD();
                System.Threading.Thread.Sleep(1300);
                Console.Clear();
            }
            if ((player.Health <= 0) && (enemy.Health > 0))
            {
                BattleInterface(player, enemy);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You were defeated....");
                Console.ResetColor();
            }
            else if ((enemy.Health <= 0) && (player.Health > 0))
            {
                BattleInterface(player, enemy);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have defeated your enemy!!");
                Console.ResetColor();
            }
            else
            {
                BattleInterface(player, enemy);
                Console.WriteLine("You are both dead...");
            }
            return;
        }

        static void BattleInterface(Player player,Enemy enemy)
        {
            Console.Write($"Health:{player.Health}\t\tEnemy Health:{enemy.Health}\t|\t ↑-For attack ↓-For special ability Your inventory:"); player.ShowInventory();
            Console.WriteLine($"\t\t\t\t\t\t\t Potion Cooldown:{player.PotionCD} Ability Cooldown:{player.AbilityCD} Damage Buff:{player.BuffCD}");
        }

        static void PerformPlayerAction(Player player, Enemy enemy)
        {
            if (player.Stun == 0)
            {
                ConsoleKey consoleKey = Console.ReadKey().Key;
                if (consoleKey == ConsoleKey.UpArrow)
                    player.DealDamage(enemy);
                else if ((consoleKey == ConsoleKey.DownArrow) && (player.AbilityCD==0))
                    player.UniqueAbility(enemy);
                else if ((((int)consoleKey - 48 > 0) && ((int)consoleKey - 48) <= player.Invenotry.Count) && (player.PotionCD==0))
                {
                    player.Invenotry[(int)consoleKey - 49].UniqueEffect(player);
                    player.Invenotry.RemoveAt((int)consoleKey - 49);
                }
                else
                {
                    Console.Clear();
                    BattleInterface(player, enemy);
                    Console.WriteLine("You have cooldown...");
                    System.Threading.Thread.Sleep(1300);
                    Console.Clear();
                    BattleInterface(player, enemy);
                    {
                        PerformPlayerAction(player, enemy);
                    }
                }
            }
            else
            {
                int IndexInInvenotry = -1;
                for(int i=0;i<player.Invenotry.Count;i++)
                {
                    if(player.Invenotry[i].Name == "Clear Potion")
                    {
                        Console.WriteLine("You have a clear potion in your inventory");
                        Console.WriteLine($"You can use it to dispel stun, if you want to do it press {i+1}");
                        IndexInInvenotry = i;
                        break;
                    }
                }
                if (IndexInInvenotry != -1)
                {
                    ConsoleKey consoleKey = Console.ReadKey().Key;
                    if((int)consoleKey-49==IndexInInvenotry)
                    {
                        player.Invenotry[IndexInInvenotry].UniqueEffect(player);
                        player.Invenotry.RemoveAt(IndexInInvenotry);
                        Console.Clear();
                        BattleInterface(player, enemy);
                        PerformPlayerAction(player, enemy);
                    }
                }
                else
                {
                    Console.WriteLine("Player is in stun");
                    System.Threading.Thread.Sleep(1300);
                }
            }
        }
        static void PerformEnemyAction(Enemy enemy,Player player)
        {
            if ((enemy.Stun == 0)&&(player.Invise==0)&&(enemy.AbilityCD==0)&&(enemy.EnabledAbility==true))
                enemy.UniqueEffect(player);
            else if ((enemy.Stun == 0) && (player.Invise == 0) && ((enemy.AbilityCD != 0)||(enemy.EnabledAbility==false)))
                enemy.DealDamage(player);
            else if(player.Invise!=0)
                Console.WriteLine("Player is invisible");
            else if (enemy.Stun != 0)            
               Console.WriteLine("Enemy is in stun");
            
        }

        static void CreatingCharacter()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Choose the level of difficulty");
                Console.WriteLine("\t1-Easy. Enemies have normal amount of health,damage and armor");
                Console.WriteLine("\t2-Moderate. Enemies have +20% to thier health,damage and armor");
                Console.WriteLine("\t3-Hard. Enemies have +25% to thier health,damage and armor,they can use abilities\n");
                int Choice=int.Parse(Console.ReadLine());
                DifficultyLevel difficultyLevel=0;
                switch (Choice)
                {
                    case 1:
                        difficultyLevel = DifficultyLevel.Easy;
                        break;
                    case 2:
                        difficultyLevel = DifficultyLevel.Moderate;
                        break;
                    case 3:
                        difficultyLevel = DifficultyLevel.Hard;
                        break;
                    default:
                        CreatingCharacter();
                        break;
                }
                Console.Clear();
                string PlayerClass = string.Empty;
                string Enemy = string.Empty;
                string ChosenWeapon = string.Empty;
                Player CurrentPlayer = ChoosingClass(ref PlayerClass);
                ChoosingWeapon(CurrentPlayer, ref ChosenWeapon, PlayerClass);
                ChoosingPotions(CurrentPlayer);
                Enemy CurrentEnemy = ChoosingEnemies(ref Enemy,difficultyLevel);
                Console.WriteLine($"\t\t{PlayerClass}\t\t{Enemy}");
                Console.WriteLine($"Health:\t\t{CurrentPlayer.Health}\t\t{CurrentEnemy.Health}");
                Console.WriteLine($"Damage:\t\t{CurrentPlayer.Damage}\t\t{CurrentEnemy.Damage}");
                Console.WriteLine($"Evade Chance:\t{CurrentPlayer.EvadeChance}%\t\t{CurrentEnemy.EvasionChance}%");
                if (CurrentPlayer.UsingShield == true)
                {
                    Console.WriteLine($"Armor rate:\t{CurrentPlayer.Armor * 2}\t\t{CurrentEnemy.Armor}");
                    Console.WriteLine($"Block chance:\t10%");
                }
                else
                {
                    Console.WriteLine($"Armor rate:\t{CurrentPlayer.Armor}\t\t{CurrentEnemy.Armor}");
                }

                Console.Write("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
                BattleProcess(CurrentPlayer, CurrentEnemy);
            }
            catch
            {
                Console.WriteLine("Wrong input format\nThe application ends....");
            }
        }  
        
        static Player ChoosingClass(ref string PlayerClass)
        {
            int Choice = -1;
            while (true)
            {
                Console.WriteLine("Choosing class:");
                Console.WriteLine("\t1-Warrior");
                Console.WriteLine("\t2-Mage");
                Console.WriteLine("\t3-Rogue");
                Console.WriteLine("\t4-Hunter");
                Choice = int.Parse(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        PlayerClass = "Warrior";
                        Console.Clear();
                        return new Warrior();
                    case 2:
                        PlayerClass = "Mage";
                        Console.Clear();
                        return new Mage();
                    case 3:
                        PlayerClass = "Rogue";
                        Console.Clear();
                        return new Rogue();
                    case 4:
                        PlayerClass = "Hunter";
                        Console.Clear();
                        return new Hunter();
                    default:
                        Console.WriteLine("You have chosen wrong option...\nTry again");
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        continue;
                }
            }
        }
        static void ChoosingWeapon(Player CurrentPlayer,ref string ChosenWeapon,string PlayerClass)
        {
            int Choice = -1;
            bool ChoosingWeaponProccess = true;
            while (ChoosingWeaponProccess)
            {
                Console.WriteLine("Chosing weapon:");
                Console.WriteLine("\t1-Dagger");
                Console.WriteLine("\t2-Fist");
                Console.WriteLine("\t3-Two Hand Axe");
                Console.WriteLine("\t4-Staff");
                Console.WriteLine("\t5-PoleArm");
                if (PlayerClass == "Hunter")
                    Console.WriteLine("\t6-Bow (only for hunters)");
                Choice = int.Parse(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        CurrentPlayer.UsingWeapon = new Dagger();
                        CurrentPlayer.ReduceCapacity();
                        ChosenWeapon = "Dagger";
                        ChoosingWeaponProccess = false;
                        break;
                    case 2:
                        CurrentPlayer.UsingWeapon = new Fist();
                        CurrentPlayer.ReduceCapacity();
                        ChosenWeapon = "Fist";
                        ChoosingWeaponProccess = false;
                        break;
                    case 3:
                        CurrentPlayer.UsingWeapon = new TwoHandAxe();
                        CurrentPlayer.ReduceCapacity();
                        CurrentPlayer.ReduceCapacity();
                        ChosenWeapon = "Two Hand Axe";
                        ChoosingWeaponProccess = false;
                        break;
                    case 4:
                        CurrentPlayer.UsingWeapon = new Staff();
                        CurrentPlayer.ReduceCapacity();
                        CurrentPlayer.ReduceCapacity();
                        ChosenWeapon = "Staff";
                        ChoosingWeaponProccess = false;
                        break;
                    case 5:
                        CurrentPlayer.UsingWeapon = new PoleArm();
                        CurrentPlayer.ReduceCapacity();
                        CurrentPlayer.ReduceCapacity();
                        ChosenWeapon = "PoleArm";
                        ChoosingWeaponProccess = false;
                        break;
                    case 6:
                        if (PlayerClass == "Hunter")
                        {
                            CurrentPlayer.UsingWeapon = new Bow();
                            CurrentPlayer.ReduceCapacity();
                            CurrentPlayer.ReduceCapacity();
                            ChosenWeapon = "Bow";
                            ChoosingWeaponProccess = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong option...\nTry again");
                            System.Threading.Thread.Sleep(1500);
                            Console.Clear();
                            continue;
                        }
                    default:
                        Console.WriteLine("Wrong option...\nTry again");
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        continue;
                }
            }
            if (CurrentPlayer.UsingWeapon.OneHand == true)
            {
                Console.WriteLine("You have chosen one-hand weapon");
                Console.WriteLine("you have opportunity to put on a shield or take one more potion in your inventory\n");
                Console.WriteLine("Shield's characteristics:");
                Console.WriteLine("\tDoubles your armor raiting");
                Console.WriteLine("\tGive you 10% chance to BLOCK enemy heat (you will receive 0 damage)\n");
                Console.WriteLine("Press Space to equip shield or another button to continue");
                ConsoleKey consoleKey = Console.ReadKey().Key;
                if (consoleKey == ConsoleKey.Spacebar)
                {
                    CurrentPlayer.UsingShield = true;
                    CurrentPlayer.ReduceCapacity();
                }
            }
            Console.Clear();
        }
        static void ChoosingPotions(Player CurrentPlayer)
        {
            int Choice = -1;
            bool ChoosingPotionsProcess = true;
            while (ChoosingPotionsProcess)
            {
                while (CurrentPlayer.Capacity != 0)
                {
                    Console.WriteLine("Chosing potions:");
                    Console.WriteLine("\t1-Healing Potion");
                    Console.WriteLine("\t2-Rage Potion");
                    Console.WriteLine("\t3-Clear Potion");
                    Console.WriteLine($"Inventory capacity:{CurrentPlayer.Capacity}");
                    Choice = int.Parse(Console.ReadLine());
                    switch (Choice)
                    {
                        case 1:
                            CurrentPlayer.ReduceCapacity();
                            CurrentPlayer.Invenotry.Add(new HealingPotion());
                            break;
                        case 2:
                            CurrentPlayer.ReduceCapacity();
                            CurrentPlayer.Invenotry.Add(new RagePotion());
                            break;
                        case 3:
                            CurrentPlayer.ReduceCapacity();
                            CurrentPlayer.Invenotry.Add(new ClearPotion());
                            break;
                        default:
                            Console.WriteLine("Wrong Option....\nTry again");
                            System.Threading.Thread.Sleep(1500);
                            Console.Clear();
                            continue;
                    }
                    Console.Clear();
                }
                Console.WriteLine("Your potions:");
                CurrentPlayer.ShowInventory();
                Console.WriteLine();
                Console.WriteLine("Do you want to choose potions again?");
                Console.WriteLine("Press any button if no");
                Console.WriteLine("Press Backspace if yes");
                ConsoleKey consoleKey = Console.ReadKey().Key;
                switch (consoleKey)
                {
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        CurrentPlayer.RenewCapacity();
                        continue;
                    default:                       
                        Console.Clear();
                        ChoosingPotionsProcess = false;
                        break;
                }
            }
        }
        static Enemy ChoosingEnemies(ref string EnemyName,DifficultyLevel difficultyLevel)
        {
            Random rand = new Random();
            int Choice = rand.Next(1, 3);
            switch (Choice)
            {
                case 1:
                    EnemyName = "Orc";
                    return new Orc(difficultyLevel);
                case 2:
                    EnemyName = "Goblin";
                    return new Goblin(difficultyLevel);
                case 3:
                    EnemyName = "Gnome";
                    return new Gnome(difficultyLevel);
            }
            return new Orc(difficultyLevel);
        }

        static void GetPlayerInfo()
        {
            Console.Clear();
            ConsoleKey consoleKey;
            Player.GetClassesInfo();
            Console.WriteLine("Press Enter to continue...");
            consoleKey = Console.ReadKey().Key;
            if (consoleKey == ConsoleKey.Enter)
                GetWeaponInfo();
            else
            {
                Console.WriteLine("Wrong input value...");
                return;
            }
        }
        static void GetWeaponInfo()
        {
            Console.Clear();
            ConsoleKey consoleKey;
            Weapon.GetWeaponsInfo();
            Console.WriteLine("Press Enter to continue...");
            consoleKey = Console.ReadKey().Key;
            if (consoleKey == ConsoleKey.Enter)
                GetPotionsInfo();
            else if (consoleKey == ConsoleKey.Backspace)
                GetPlayerInfo();
            else
            {
                Console.WriteLine("Wrong input value...");
                return;
            }
        }
        static void GetPotionsInfo()
        {
            Console.Clear();
            ConsoleKey consoleKey;
            Potion.GetPotionsInfo();
            Console.WriteLine("Press Enter to continue...");
            consoleKey = Console.ReadKey().Key;
            if (consoleKey == ConsoleKey.Enter)
                GetEnemyInfo();
            else if (consoleKey == ConsoleKey.Backspace)
                GetWeaponInfo();
            else
            {
                Console.WriteLine("Wrong input value...");
                return;
            }
        }
        static void GetEnemyInfo()
        {
            Console.Clear();
            ConsoleKey consoleKey;
            Enemy.GetEnemiesInfo();
            Console.WriteLine("Press Enter to continue...");
            consoleKey = Console.ReadKey().Key;
            if (consoleKey == ConsoleKey.Enter)
                CreatingCharacter();
            else if (consoleKey == ConsoleKey.Backspace)
                GetPotionsInfo();
            else
            {
                Console.WriteLine("Wrong input value...");
                return;
            }
        }
    }
}
