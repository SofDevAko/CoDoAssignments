using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human arandil = new Human("Arandil the Great");
            Human beldar = new Human("Beldar the Brave");
            int num = 5;

            arandil.attack(beldar);
            System.Console.WriteLine(beldar.health);
            arandil.attack(num);
        }
    }
}
