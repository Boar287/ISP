using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int TheEndOfTheWord = 0;
            int BeginOfTheWord = 0;
            Console.Write("Enter your statement:");
            string TheStatement = Console.ReadLine();
            string TheFinalStatement = String.Concat(" ", TheStatement);
            char[] TheFinalStatementChar = TheFinalStatement.ToCharArray();
            Array.Reverse(TheFinalStatementChar);
            Console.Write("Your final statement:");
            for (int i = 0; i < TheFinalStatementChar.Length; i++)
            {
                if (TheFinalStatementChar[i] == ' ')
                {
                    if (TheEndOfTheWord == 0)
                    {
                        BeginOfTheWord = 0;
                        TheEndOfTheWord = i;
                        for (int j = TheEndOfTheWord - 1; j >= BeginOfTheWord; j--)
                        {
                            Console.Write(TheFinalStatementChar[j]);
                        }
                    }
                    else if (TheEndOfTheWord != 0)
                    {
                        BeginOfTheWord = TheEndOfTheWord + 1;
                        TheEndOfTheWord = i;
                        for (int j = TheEndOfTheWord; j >= BeginOfTheWord; j--)
                        {
                            Console.Write(TheFinalStatementChar[j]);
                        }
                    }
                }

            }
        }

    }
}
