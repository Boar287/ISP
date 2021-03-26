using System;
using System.Text;

namespace Laba3_task1
{
    class University
    {
        public static void CalculatingScholarships(Student student)
        {
            if ((student.StateStudent == true)&&(student.NumberOfRetakes==0))
            {
                if (student.AverageMark > 9.0)
                    Console.WriteLine("The Scholarship rate of " + student.FullName + " is 1.6");
                else if (student.AverageMark > 8.0)
                    Console.WriteLine("The Scholarship rate of " + student.FullName + " is 1.4");
                else if (student.AverageMark > 6.0)
                    Console.WriteLine("The Scholarship rate of " + student.FullName + " is 1.2");
                else if (student.AverageMark > 5.0)
                    Console.WriteLine("The Scholarship rate of " + student.FullName + " is 1");
                else if (student.AverageMark > 4.0)
                    Console.WriteLine("The Scholarship of " + student.FullName + " is one base value");
            }
            else if((student.StateStudent == true)&&(student.NumberOfRetakes!=0))
            {
                Console.WriteLine(student.FullName+" was deprived of the scholarship due to the number of retakes");
            }
            else
            {
                Console.WriteLine("Only State Students have scholarships");
            }
            Console.WriteLine();
        }
        public static void Session(Student student)
        {
            if(student.StateStudent==true)
            {
                if(student.NumberOfRetakes>1)
                    Console.WriteLine(student.FullName+" has been excluded due to the number of retakes" );
                else
                    Console.WriteLine(student.FullName+" has succesfully passed the examas");
            }
            else if(student.StateStudent==false)
            {
                if (student.NumberOfRetakes >2)
                    Console.WriteLine(student.FullName + " has been excluded due to the number of retakes");
                else
                    Console.WriteLine(student.FullName + " has succesfully passed the examas");
            }
            Console.WriteLine();
        }
    }
}
