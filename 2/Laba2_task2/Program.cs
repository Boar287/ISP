using System;

namespace Laba2_task2
{
    class Program
    {
      
        static int Main(string[] args)
        {
            bool EnteringTheStatement = true;
            string Statement="";
            while (EnteringTheStatement)
            {
                Console.Write("Enter your statement:");
                Statement = Console.ReadLine();
                if (StringValidation(Statement)==false)
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
            char[] StatementChar = Statement.ToCharArray();
            ChangingTheStatement(StatementChar);
            Statement = new string(StatementChar);
            Console.WriteLine($"Your changed statement:{Statement}");
            return 0;
        }
        static bool SearchingForVowels(char ElemntOfStatementChar)
        {
            string Vowels = "EeYyUuOoIiAa";
            for (int i = 0; i < Vowels.Length; i++)
            {
                if (ElemntOfStatementChar == Vowels[i])
                    return true;
            }
            return false;
        }
        static void ChangingTheStatement(char[] StatementChar)
        {
            for (int i = 0; i < StatementChar.Length - 1; i++)
            {
                if (SearchingForVowels(StatementChar[i]))
                {
                    if (StatementChar[i + 1] == 'z')
                        StatementChar[i + 1] = 'a';

                    else if (StatementChar[i + 1] == 'Z')
                        StatementChar[i + 1] = 'A';
                    else
                        StatementChar[i + 1] = Convert.ToChar(Convert.ToInt32(StatementChar[i + 1]) + 1);

                    i++;
                }
            }
        }
        static bool StringValidation(string Statement)
        {
            foreach (char letter in Statement)
            {
                if ((Char.IsLetter(letter) != true) && (letter != ' '))
                    return false;
            }
            return true;
        }
    }
}
