using System;
using System.Text;

namespace Laba3_task1
{
    class Human
    {
        protected string _FullName;
        protected string _DateOfBirth;
        protected char _Gender;
        private static int _Number = 0;
        public Human() { _Number++; }
        public static int Number { get { return _Number-1; } }
        public string FullName
        {
            get { return _FullName; }
            set
            {
                if (MyValidations.StringValidation(value) == false)
                    throw new Exception("Wrong Name format\nOnly latters are aveilable");
                else
                    _FullName = value;
            }
        }
        protected string DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                if (MyValidations.NumericValidation(value) == false)                
                    throw new Exception("Wrong Date of Birth format");
                else
                    _DateOfBirth = value;
            }
        }
        protected char Gender
        {
            get { return _Gender; }
            set
            {
                if ((Char.ToUpper(value) != 'M') && (Char.ToUpper(value) != 'W'))
                    throw new Exception("Wrong Gender format\nOnly\"M\" and \"W\" are avelaible");
                else
                    _Gender = value;
            }
        }
        protected void SetHumanData()
        {
            Console.Write("Entering full name:");
            FullName = Console.ReadLine();
            Console.Write("  Entering the birth date:");
            DateOfBirth = Console.ReadLine();
            Console.Write("  Entering the gender (\"M\" or \"W\"):");
            Gender = Convert.ToChar(Console.ReadLine());
        }
        protected void GetHumanData()
        {
            Console.WriteLine("Full Name:"+_FullName);
            Console.WriteLine("  Date of Birth:"+_DateOfBirth);
            Console.WriteLine("  Gender:"+_Gender);
        }
    }
}
