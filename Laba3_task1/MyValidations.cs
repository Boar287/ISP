using System;
using System.Text;

namespace Laba3_task1
{
    class MyValidations
    {
        public static bool StringValidation(String Line)
        {
            for (int i = 0; i < Line.Length; i++)
            {
                if ((Char.IsLetter(Line[i]) == false) && (Line[i] != ' '))
                    return false;
            }
            return true;
        }
        public static bool NumericValidation(String Line)
        {
            for (int i = 0; i < Line.Length; i++)
            {
                if ((Char.IsDigit(Line[i]) == false) && (Line[i] != '.'))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool EmailValidation(String Line)
        {
            if (Line.Length < 10)
                return false;
            for(int i=0;i<Line.Length;i++)
            {
                if (Line[i] == '@')
                    return true;
            }
            return false;
        }
    }
}
