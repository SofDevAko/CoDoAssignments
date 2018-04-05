using System;
using System.Collections.Generic;

namespace boxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
           List<object> boxList = new List<object>();
           boxList.Add(7);
           boxList.Add(28);
           boxList.Add(-1);
           boxList.Add(true);
           boxList.Add("chair");
           int sum = 0;
           foreach (var item in boxList){
               Console.WriteLine(item);
               if (item is int){
                sum += (int)(item);
               }
               
           }
           Console.WriteLine(sum);
        }
    }
}
