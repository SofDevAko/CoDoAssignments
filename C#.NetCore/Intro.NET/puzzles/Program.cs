using System;
using System.Collections.Generic;

namespace puzzles
{
    class Coin
    {
        //Coin Flip
        public string TossCoin()
        {
            Random rnd = new Random();
            string tossres = "";
            int result = rnd.Next(1,3);
            if (result == 1)
            {
                tossres = "heads";
            }
            if (result == 2)
            {
                tossres = "tails";
            }
            return tossres;
        }

        //Toss Multiple Coins

        public double TossMultipleCoins(int num)
        {

            Random rnd = new Random();
            int headtoss = 0;
            for (int i = 0; i < num; i++)
            {
                int result = rnd.Next(1,3);
                if (result == 1)
                {
                   headtoss += 1;
                }
                
            }
           
            return (double)headtoss/(double)num;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // //Random Array
            // int[] arr = new int[10];
            // Random rnd = new Random();
            
            // for (int i = 0; i < arr.Length; i++)
            // {
            //     int num = rnd.Next(5,26);
            //     arr[i] = num;
            // }
            // int max = arr[0];
            // int min = arr[0];
            // int sum = 0;

            // for (int i = 0; i < arr.Length; i++)
            // {
            //     if (i < min)
            //     {
            //         min = arr[i];
            //     }
            //     else if (i > max)
            //     {
            //         max = arr[i];
            //     }
            //     sum += arr[i];
            // }
            // System.Console.WriteLine("Max is: {0}, Min is: {1}, sum is: {2}",max, min, sum);

            // //Coin Flip
            // Coin coin = new Coin();
            // double tossres = coin.TossMultipleCoins(10);
            // System.Console.WriteLine(tossres);

            //Names
            Random rnd = new Random();
            string[] arr = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            for (int i = 0; i < arr.Length; i++)
            {
                int index = rnd.Next(0,arr.Length);
                string temp = arr[index];
                arr[index] = arr[i];
                arr[i] = temp;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.WriteLine(arr[i]);
            }
            List <string> newlist = new List <string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length > 5)
                {
                    newlist.Add(arr[i]);
                }
            }
            for (int i = 0; i < newlist.Count; i++)
            {
                System.Console.WriteLine("New list is: "+newlist[i]);
            }
        }
    }
}
