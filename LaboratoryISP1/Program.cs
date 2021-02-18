using System;
using System.Text;
namespace ISPLaba1
{
    class Program
    {
        static int Main(string[] args)
        {
            string HiddenWord = "";
            bool EnteringHiddenWord = true;

            while (EnteringHiddenWord)
            {
                Console.Write("Enter the hidden word:");
                HiddenWord = Console.ReadLine();

                Console.WriteLine("Press Enter to continue or any button to rechoice the hidden word");
                ConsoleKey LastChance = Console.ReadKey().Key;
                switch (LastChance)
                {
                    case ConsoleKey.Enter:
                        EnteringHiddenWord = false;
                        break;

                    default:
                        Console.Clear();
                        continue;
                }
            }

            if (!CheckTheString(HiddenWord))
            {
                Console.WriteLine("You have entered wrong symbols, the program has finished\a");
                return 1;
            }

            Console.Clear();
            char EnteredLetter;
            bool GameProcess = true;
            int TheNumberOfGuessedLetter = 0;
            int MaxNumberOfAttempts = 6;
            int CurrentNumberOfAttempts = 0;
            char[] AlreadyGuessedLetters = new char[HiddenWord.Length * 2 - 1];
            for (int i = 0; i < AlreadyGuessedLetters.Length; i++)
            {
                if (i % 2 == 0)
                    AlreadyGuessedLetters[i] = '_';
                else
                    AlreadyGuessedLetters[i] = ' ';

            }



            while (GameProcess)
            {

                HangedMan(CurrentNumberOfAttempts);
                ShowALreadyGuessedLetters(AlreadyGuessedLetters);
                Console.WriteLine("Enter the possible letter in this word:");
                try
                {
                    EnteredLetter = Convert.ToChar(Console.ReadLine());
                    if (!Char.IsLetter(EnteredLetter))
                    {
                        Console.WriteLine("You have entered invalid value");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("You have entered invalid value");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }

                if (AlreadyEntered(AlreadyGuessedLetters, EnteredLetter))
                {
                    Console.WriteLine("You have already entered this letter!");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    continue;

                }

                if (SearchingForLetter(HiddenWord, EnteredLetter))
                {
                    for (int i = 0; i < HiddenWord.Length; i++)
                    {
                        if (Char.ToLower(HiddenWord[i]) == Char.ToLower(EnteredLetter))
                        {
                            AlreadyGuessedLetters[2 * i] = HiddenWord[i];
                            TheNumberOfGuessedLetter++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Unfortunately, you are wrong");
                    CurrentNumberOfAttempts++;
                    System.Threading.Thread.Sleep(1000);
                }


                if (MaxNumberOfAttempts == CurrentNumberOfAttempts)
                {
                    Console.Clear();
                    HangedMan(CurrentNumberOfAttempts);
                    Console.WriteLine("You have lost");
                    Console.WriteLine("The hidden word was:" + HiddenWord);
                    GameProcess = false;
                    Console.ReadLine();
                }
                if (HiddenWord.Length == TheNumberOfGuessedLetter)
                {
                    Console.Clear();
                    HangedMan(CurrentNumberOfAttempts);
                    ShowALreadyGuessedLetters(AlreadyGuessedLetters);
                    Console.WriteLine();
                    Console.WriteLine("You have guessed the word");
                    GameProcess = false;
                    Console.ReadLine();
                }
                Console.Clear();
            }

            return 0;
        }




        static bool CheckTheString(string HiddenWord)
        {
            foreach (char letter in HiddenWord)
            {
                if (!Char.IsLetter(letter))
                    return false;
            }
            return true;
        }

        static bool SearchingForLetter(string HiddenWord, char EnteredLetter)
        {
            for (int i = 0; i < HiddenWord.Length; i++)
            {
                if (Char.ToLower(HiddenWord[i]) == Char.ToLower(EnteredLetter))
                    return true;
            }
            return false;
        }
        static bool AlreadyEntered(char[] AlreadyGuessedLetters, char EnteredLetter)
        {
            for (int i = 0; i < AlreadyGuessedLetters.Length; i++)
            {
                if (Char.ToLower(AlreadyGuessedLetters[i]) == Char.ToLower(EnteredLetter))
                    return true;
            }
            return false;
        }

        static void ShowALreadyGuessedLetters(char[] AlreadyGuessedLetters)
        {
            Console.WriteLine("\tYour word is:");
            Console.Write("\t");
            for (int i = 0; i < AlreadyGuessedLetters.Length; i++)
            {

                Console.Write(AlreadyGuessedLetters[i]);
            }
            Console.WriteLine();
        }

        static void HangedMan(int CurrentNumberOfAttempts)
        {
            switch (CurrentNumberOfAttempts)
            {

                case 0:
                    Console.Write("\n" +
        "\n" +
        "\n" +
        "\n" +
        "\n" +
        "\n" +
        "\n" +
        "\n" +
        "\n" +
        "\n" +
        "\n" +
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n" +
        " $                          $\n");
                    break;
                case 1:
                    Console.Write("        $$$$$$$$$$$$$$$\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n" +
        " $                          $\n");
                    break;
                case 2:
                    Console.Write("        $$$$$$$$$$$$$$$\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        |             $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n" +
        " $                          $\n");
                    break;
                case 3:
                    Console.Write("        $$$$$$$$$$$$$$$\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        O             $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n" +
        " $                          $\n");
                    break;
                case 4:
                    Console.Write("        $$$$$$$$$$$$$$$\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        O             $\n" +
        "      /   \\           $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n" +
        " $                          $\n");
                    break;
                case 5:
                    Console.Write("        $$$$$$$$$$$$$$$\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        O             $\n" +
        "      / | \\           $\n" +
        "        |             $\n" +
        "                      $\n" +
        "                      $\n" +
        "                      $\n" +
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n" +
        " $                          $\n");
                    break;
                case 6:
                    Console.Write("        $$$$$$$$$$$$$$$\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        |             $\n" +
        "        O             $\n" +
        "      / | \\           $\n" +
        "        |             $\n" +
        "       / \\            $\n" +
        "                      $\n" +
        "                      $\n" +
        " $$$$$$$$$$$$$$$$$$$$$$$$$$$$\n" +
        " $                          $\n");
                    break;

            }
        }
    }
}
