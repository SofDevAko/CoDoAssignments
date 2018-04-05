using System;

namespace WizNinSam
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard Arandil = new Wizard("Arandil");
            Ninja Gerrath = new Ninja("Gerrath");
            Samurai Beldar = new Samurai("Beldar");

            Beldar.attack(Gerrath);
            System.Console.WriteLine("================================");
            Gerrath.Drain_Life(Beldar);
            System.Console.WriteLine("================================");
            Arandil.Heal(Gerrath);
            System.Console.WriteLine("================================");
            Gerrath.Get_Away();
            System.Console.WriteLine("================================");
            Arandil.Fireball(Beldar);
            System.Console.WriteLine("================================");
            Beldar.Death_Blow(Arandil);
            System.Console.WriteLine(Arandil.health);
            System.Console.WriteLine("================================");
            Beldar.Meditate();
        }
    }
}
