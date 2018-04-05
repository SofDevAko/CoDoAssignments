using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            // //Print 1-255
            // for (int i = 1; i < 256; i++){
            // Console.WriteLine(i);
            // }

            // //Print odd numbers between 1-255
            // for (int i = 1; i < 256; i++){
            //     if (i % 2 != 0){
            //         Console.WriteLine(i);
            //     }
            // }

            // //Print Sum
            // int sum = 0;
            // for (var i = 0; i < 256; i++){
            //     sum += i;
            //     Console.WriteLine("New number is: {0} and Sum is: {1}", i, sum);
            // }

            // //Iterating through an Array
            // int[] x = {1,3,5,7,9,13};
            // for (int i = 0; i <= x.Length-1; i++){
            //     Console.WriteLine(x[i]);
            // }

            // //Find Max
            
            // int[] arr = {1,-3,5,-7,9,-13};
            // int max = arr[0];
            // for (int i = 0; i <= arr.Length-1; i++){
            //     if (max < arr[i]){
            //         max = arr[i];
            //     }
               
            // }
            // Console.WriteLine(max);
            
            // //Get Average
            // int[] arr = {1,-3,5,-7,9,-13,24};
            // int sum = 0;
            // for (var i = 0; i < arr.Length-1; i++){
            //     sum += i;
               
            // }
            // Console.WriteLine("Average is: {0}", sum/(arr.Length));

            //Array with Odd Numbers
            // List<int> newlist = new List<int>();
            // for (int i = 1; i < 256; i++){
            //     if (i % 2 != 0){
            //         newlist.Add(i);
                   
            //     }
               
            // }
            // for (int i = 0; i<newlist.Count; i++){    //Loop to show all the elements of newlist
            //     Console.WriteLine(newlist[i]);
            // }

            // //Greater than Y
            // int[] arr = {1,3,5,7,9};
            // int y = 3;
            // int count = 0;
            // for (var i = 0; i < arr.Length; i++){
            //     if (arr[i] > y){
            //         count++;
            //     }
            // }
            // Console.WriteLine(count);

            // //Square the Values
            // int[] arr = {1,5,10,-2};
            // for (int i = 0; i < arr.Length; i++){
            //     arr[i] = arr[i]*arr[i];
            // }
            // for (int i = 0; i < arr.Length; i++){
            //     Console.WriteLine(arr[i]);
            // }

            // //Eliminate Negative Numbers
            // int[] arr = {1,5,10,-2};
            // for (int i = 0; i < arr.Length; i++){
            //    if (arr[i] < 0){
            //        arr[i] = 0;
            //    }
            // }
            // for (int i = 0; i < arr.Length; i++){
            //     Console.WriteLine(arr[i]);
            // }

            // //Min, Max and Average
            // int[] arr = {1,-3,5,-7,9,-13,24};
            // int sum = 0;
            // int min=arr[0];
            // int max=arr[0];
            // for (var i = 0; i < arr.Length-1; i++){
            //     if (arr[i] > max){
            //         max = arr[i];
            //     }
            //     if (arr[i] < min){
            //         min = arr[i];
            //     }
            //     sum += i;
            // }
            // Console.WriteLine("Average is: {0}, Max is: {1}, Min is {2}", sum/(arr.Length), max, min);

            // //Shifting the values in an array
            // int[] arr = {1,5,10,7,9};
            // for (int i = 0; i < arr.Length-1; i++)
            // {
            //     arr[i] = arr[i+1];
            // }
            // arr[arr.Length-1] = 0;
            // for (int i = 0; i < arr.Length; i++){
            //     Console.WriteLine(arr[i]);
            // }    

            //Number to String
            object[] arr = {1,-5,10,-7,9};
            string neg = "negative";
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] is int)
                {
                    int num = (int)arr[i];
                    if (num < 0)
                {
                    arr[i] = neg;
                }
                }
            }
            arr[arr.Length-1] = 0;
            for (int i = 0; i < arr.Length; i++){
                Console.WriteLine(arr[i]);
            }    
        }
    }
}
