using System;
using System.Collections.Generic;
using System.Text;

namespace Laba3_task1
{
    class PersonalData
    {
        private string Adress { get; set; }
        private string _TelephoneNumber;
        private string _Email;
        private string TelephoneNumber
        {            
            get { return _TelephoneNumber; }
            set
            {
                if (MyValidations.NumericValidation(value) == false)
                    throw new Exception("Wrong Telephone number format\nOnly numbers are avelaible");
                else
                    _TelephoneNumber = value;
            }
        }
        private string Email
        {
            get { return _Email; }
            set
            {
                if (MyValidations.EmailValidation(value) == false)
                    throw new Exception("Wrong Email format\nThe length of email should be more than 10 and the symbol \"@\" is required");
                else
                    _Email = value;
            }
        }
        public void SetPresonalDataInfo()
        {
            Console.Write("\tEntering Adress:");
            Adress = Console.ReadLine();
            Console.Write("\tEntering Telephone Number:");
            TelephoneNumber =Console.ReadLine();
            Console.Write("\tEntering Email:");
            Email = Console.ReadLine();
        }
        public void GetPersonalDataInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tPersonal data:");
            Console.ResetColor();
            Console.WriteLine("\tAdress:"+Adress);
            Console.WriteLine("\tTelephone Number:"+TelephoneNumber);
            Console.WriteLine("\tEmail:"+Email);
        }
    }
}
