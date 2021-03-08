using System;

namespace Laba2_task4
{
    class Program
    {
        static long CountingMultiplication(long BeginofDiaposon,long EndOfDiaposon)
        {
            if (BeginofDiaposon == EndOfDiaposon)
                return BeginofDiaposon;
            return EndOfDiaposon * CountingMultiplication(BeginofDiaposon, EndOfDiaposon-1);
        }
        static int SearchingForDegree(long BeginofDiaposon, long EndOfDiaposon)
        {
            long Multiplication = CountingMultiplication(BeginofDiaposon, EndOfDiaposon);
            int NumberOfDegree = 0;
            while (Multiplication % Math.Pow(2, NumberOfDegree) == 0)
                NumberOfDegree++;
            return NumberOfDegree-1;
        }
        static int Main(string[] args)
        {
            long BeginOfDiaposon=0,EndOfDiaposon=0;
            try
            {
                Console.Write("Enter the beginnig of the numeric rows:");
                BeginOfDiaposon = Convert.ToInt64(Console.ReadLine());
                Console.Write("Enter the end of the numeric rows:");
                EndOfDiaposon = Convert.ToInt64(Console.ReadLine());                
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong format of numbers");
                return -1;
            }
            if(BeginOfDiaposon>EndOfDiaposon)
            {
                long temp = BeginOfDiaposon;
                BeginOfDiaposon = EndOfDiaposon;
                EndOfDiaposon = temp;
            }
            if((BeginOfDiaposon==0)||(EndOfDiaposon==0)||(BeginOfDiaposon+EndOfDiaposon<Math.Abs(BeginOfDiaposon)+Math.Abs(EndOfDiaposon)))
                Console.WriteLine("The multiplication is 0 so the degree of 2 can be any");
            else
                Console.WriteLine($"The maximum degree of 2 is:{SearchingForDegree(BeginOfDiaposon, EndOfDiaposon)}");
            return 0;
        }
    }
}
