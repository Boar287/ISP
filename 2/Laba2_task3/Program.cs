using System;

namespace Laba2_task3
{
    class Program
    {
        static bool StringValidation(string Statement)
        {
            foreach (char letter in Statement)
            {
                if ((Char.IsLetter(letter) != true) && (letter != ' '))
                    return false;
            }
            return true;
        }
        static void SearchingForStrangeLetters(string Statement)
        {
            for(int i=0;i<Statement.Length;i++)
            {
                if(Char.IsUpper(Statement[i]))
                {
                    if((Convert.ToInt32(Statement[i])<65)||(Convert.ToInt32(Statement[i])>90))
                    {
                        if (Char.IsLetter(Statement[i]))
                        {
                            Console.Write(Statement[i]);
                        }
                    }
                }
            }
        }
        static int Main(string[] args)
        {
            bool EnteringTheStatement = true;
            string Statement = "";
            while (EnteringTheStatement)
            {
                Console.Write("Enter your statement:");
                Statement = Console.ReadLine();
                if (StringValidation(Statement) == false)
                {
                    Console.WriteLine("Wrong format of statement\nPress Enter if you want to reenter the statement");
                    ConsoleKey LastChance = Console.ReadKey().Key;
                    switch (LastChance)
                    {
                        case ConsoleKey.Enter:
                            Console.Clear();
                            continue;
                        default:
                            return -1;
                    }
                }
                else
                    EnteringTheStatement = false;
            }
            Console.Write("Strange letters in your statement:");
            SearchingForStrangeLetters(Statement);
            return 0;
        }
    }
}
