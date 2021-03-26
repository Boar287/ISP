using System;

namespace Laba3_task1
{
    class Program
    {
        static int Main(string[] args)
        {
            bool Inicialization = true;
            Student student = new Student();            
            Console.Write("Enter the nubmer of students in database:");
            Student.Size = int.Parse(Console.ReadLine());
            Console.Clear();
            int Index = 0;
            while (Inicialization)
            {
                try
                {
                    Console.Write(Index+1+")");
                    student[Index] = new Student();
                    student[Index].SetStudentData();
                    Index++;
                    if(Index==Student.Size)
                    Inicialization = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press Enter to refill correct information");
                    ConsoleKey choice = Console.ReadKey().Key;
                    {
                        switch (choice)
                        {
                            case ConsoleKey.Enter:
                                Console.Clear();
                                for(int i=0;i<Index;i++)
                                {
                                    Console.Write(i+1+")");
                                    student[i].GetStudentData();
                                }
                                continue;
                            default:
                                return -1;
                        }
                    }                    
                }
            }
            Console.Clear();            
            while (true)
            {
                student.ShowStudentsSet();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Choose option");
                Console.WriteLine("\t1-Show Session reults");
                Console.WriteLine("\t2-Show Scholarships");
                int ChoosingTheOption = -1;
                try
                {
                    ChoosingTheOption = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Wrong input data format");
                }
                switch (ChoosingTheOption)
                {
                    case 1:                        
                        Console.WriteLine("\tSession results:");
                        for (int i = 0; i < Student.Size; i++)
                        {
                            University.Session(student[i]);
                        }
                        break;
                    case 2:
                        Console.WriteLine("\tScholarships:");
                        for (int i = 0; i < Student.Size; i++)
                        {
                            University.CalculatingScholarships(student[i]);
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong option...");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                }
                Console.WriteLine("Press Enter to choose new option");
                ConsoleKey choice = Console.ReadKey().Key;
                {
                    switch (choice)
                    {
                        case ConsoleKey.Enter:
                            Console.Clear();
                            continue;
                        default:
                            return 0;
                    }
                }
            }
        }
    }
}
