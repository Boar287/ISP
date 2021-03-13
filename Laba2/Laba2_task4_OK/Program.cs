using System;

namespace Laba2_task4_OK
{
    class Program
    {
        static long SearchingForDegree(long BeginofDiaposon, long EndOfDiaposon)
        {
            long counter = 0;
            int n = 1;
            while(EndOfDiaposon>=Math.Pow(2,n))
            {
                counter += (long)(EndOfDiaposon / Math.Pow(2, n));
                n++;
            }
            n = 1;
            while(BeginofDiaposon>=Math.Pow(2,n))
            {
                counter -= (long)(BeginofDiaposon / Math.Pow(2, n));
                n++;
            }
            return counter;
        }
        static int Main(string[] args)
        {
            long BeginOfDiaposon = 0, EndOfDiaposon = 0;
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
            if (BeginOfDiaposon > EndOfDiaposon)
            {
                long temp = BeginOfDiaposon;
                BeginOfDiaposon = EndOfDiaposon;
                EndOfDiaposon = temp;
            }
            if ((BeginOfDiaposon == 0) || (EndOfDiaposon == 0) || (BeginOfDiaposon + EndOfDiaposon < Math.Abs(BeginOfDiaposon) + Math.Abs(EndOfDiaposon)))
                Console.WriteLine("The multiplication is 0 so the degree of 2 can be any");
            else
                Console.WriteLine($"The maximum degree of 2 is:{SearchingForDegree(BeginOfDiaposon, EndOfDiaposon)}");
            return 0;
        }
    }
}
