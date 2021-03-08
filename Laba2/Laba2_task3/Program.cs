using System;

namespace Laba2_task3
{
    class Program
    {
        static void CountingNumbers(string DifferentFormats)
        {
            Console.WriteLine(DifferentFormats);
            int NumberCount = 0;
            for(int number = 0; number < 10; number++)
            {
                for(int i = 0; i < DifferentFormats.Length; i++)
                {
                    if (DifferentFormats[i] == Convert.ToChar(number+'0'))                    
                        NumberCount++;                    
                }
                Console.WriteLine($"\tThe amount of {number} is {NumberCount}");
                NumberCount = 0;
            }
        }
        static int Main(string[] args)
        {
            DateTime DefoltFormat = DateTime.Now;
            CountingNumbers(Convert.ToString(DefoltFormat));
            CountingNumbers(DefoltFormat.ToLongDateString());
            return 0;
        }
    }
}
