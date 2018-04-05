using System;

namespace first_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 0;
            int end = 5;
            // loop from start to end including end
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
