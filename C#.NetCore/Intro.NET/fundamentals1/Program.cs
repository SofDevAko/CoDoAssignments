using System;

namespace fundamentals1
{
    class Program
    {
        static void Main(string[] args)
        {
            // for (int i = 1; i <= 255; i++){
            //     Console.WriteLine(i);
            // }


            // for (int i = 1; i <= 100; i++){
            //     if (i % 3 == 0 || i % 5 == 0){
            //         if (!(i % 3 == 0 && i % 5 == 0)){
            //             Console.WriteLine(i);
            //         }
            //     }
            // }

            // for (int i = 1; i <= 100; i++){
            //     if (i % 3 == 0 && i % 5 == 0){
            //        Console.WriteLine(i + "FizzBuzz");
            //     }
            //     else if (i % 3 == 0){
            //         Console.WriteLine(i + "Fizz");
            //     }
            //     else if (i % 5 == 0){
            //         Console.WriteLine(i + "Buzz");
            //     }
            // }

            // for (double i = 1; i <= 100; i++)
            // {
            //     if ((((int)(i / 3)) == (i/3)) && (((int)(i / 5)) == (i/5))){
            //        Console.WriteLine(i + "FizzBuzz");
            //     }
            //     else if (((int)(i / 3)) == ((i/3)))
            //     {
            //         Console.WriteLine(i + "Fizz");
            //     }
            //     else if (((int)(i / 5)) == (i/5))
            //     {
            //         Console.WriteLine(i + "Buzz");
            //     }
            // }
            
            Random rand = new Random();

            for (int k = 1; k <= 10; k++){
                int i = rand.Next(1,100);
                if (i % 3 == 0 && i % 5 == 0){
                   Console.WriteLine(i + "FizzBuzz");
                }
                else if (i % 3 == 0){
                    Console.WriteLine(i + "Fizz");
                }
                else if (i % 5 == 0){
                    Console.WriteLine(i + "Buzz");
                }
            }
        }
    }
}
