using System;
using System.Collections.Generic;

namespace collectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] array2 = { "Tim", "Martin", "Nikki", "Sara" };
            bool[] array3 = { true, false, true, true, false, true };

            int[,] multTable = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    multTable[i, k] = (i + 1) * (k + 1);

                }


            }
            //    Console.WriteLine(multTable[3,8]);   //This line can be used to check specific elements

            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Strawberry");
            flavors.Add("Lemon");
            flavors.Add("Watermelon");
            flavors.Add("Peach");
            Console.WriteLine(flavors.Count);
            Console.WriteLine("Third flavor is: " + flavors[3]);
            flavors.RemoveAt(3);
            Console.WriteLine("Third flavor is now changed to: " + flavors[3]);
            Console.WriteLine(flavors.Count);

            Dictionary<string, string> userInfo = new Dictionary<string, string>();
            for (int i = 0; i < array2.Length; i++)
            {
                Random rnd = new Random();
                int flavnum = rnd.Next(1, flavors.Count);
                userInfo.Add(array2[i], flavors[flavnum]);
            }
            foreach (var entry in userInfo)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
