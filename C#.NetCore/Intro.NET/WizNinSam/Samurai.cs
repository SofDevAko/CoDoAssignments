using System;

namespace WizNinSam
{
    public class Samurai : Human
    {
        public new int health = 200;

        public new int strength = 5;

        public Samurai(string name) : base(name)
        {

        }

        public void Death_Blow(Human enemy)
        {
            
            // Human enemy = target as Human;
            // if (enemy is Human)
            // {
                if (enemy.health <= 110)
                {
                    enemy.health = 0;
                    System.Console.WriteLine("{0} placed an awesome bloody Death Blow and killed {1}",name, enemy.name);
                }
                else
                {
                    System.Console.WriteLine("{0} has too much HP to be killed at once", enemy.name);
                }
                
            // }
            // else
            // {
            //     System.Console.WriteLine("You can't 'Death Blow' nothing!");
            // }
        }

        public void Meditate()
        {
            this.health = 200;
            System.Console.WriteLine("{0} sensei meditated and healed all previous wounds",name);
        }
    }
}