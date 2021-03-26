using System;
using System.Collections.Generic;
using System.Text;

namespace Laba3_task1
{
    class Student : Human
    {
        public bool StateStudent { get; private set; }
        public PersonalData PersDataOfStudent = new PersonalData();
        private string Id;
        private int _NumberOfRetakes;
        private double _AverageMark;
        private static int _Size = 0;
        public static int Size
        {
            get { return _Size; }
            set
            {
                if (value <= 0 || value > 4)
                    throw new Exception("Inappropriate size...");
                else
                {
                    _Size = value;
                    _studentsSet = new Student[_Size];
                }
            }
        }

        public int NumberOfRetakes
        {
            get { return _NumberOfRetakes; }
            set
            {
                if ((MyValidations.NumericValidation(_NumberOfRetakes.ToString()) == false) || (value > 6))
                    throw new Exception("Wrong Number of Retakes format");
                else
                    _NumberOfRetakes = value;
            }
        }
        public double AverageMark
        {
            get { return _AverageMark; }
            set
            {
                if ((value < 0) || (value > 10))
                    throw new Exception("Wrong Average mark format");
                else
                    _AverageMark = value;
            }
        }
        public void SetStudentData()
        {
            SetHumanData();
            PersDataOfStudent.SetPresonalDataInfo();
            Console.Write(" State student (true or false):");
            StateStudent = Convert.ToBoolean(Console.ReadLine());
            Console.Write(" Student't average score:");
            AverageMark = Convert.ToDouble(Console.ReadLine());
            Console.Write(" Student's number of retakes:");
            NumberOfRetakes = int.Parse(Console.ReadLine());
            Id = Guid.NewGuid().ToString();
            Console.WriteLine();
        }
        public void GetStudentData()
        {
            GetHumanData();
            PersDataOfStudent.GetPersonalDataInfo();
            Console.WriteLine(" State student:" + StateStudent);
            Console.WriteLine(" Id of the student in data base:" + Id);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tProgress Information:");
            Console.ResetColor();
            Console.WriteLine("\tAverage Score:" + AverageMark);
            Console.WriteLine("\tNumber of Retakes:" + NumberOfRetakes);
            Console.WriteLine();

        }
        private static Student[] _studentsSet;
        public Student this[int index]
        {
            get { return _studentsSet[index]; }
            set { _studentsSet[index] = value; }
        }
        public void ShowStudentsSet()
        {
            for(int i=0;i<Size;i++)
            {
                Console.Write((i+1)+")");
                _studentsSet[i].GetStudentData();
                Console.WriteLine();
            }            
        }
    }
}
