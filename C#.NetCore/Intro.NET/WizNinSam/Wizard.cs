using System;

namespace WizNinSam
{
    public class Wizard : Human
    {
        Random rnd = new Random();
        

        public Wizard(string name) : base(name)
        {
            health = 50;
            intelligence = 25;
        }

        public void Heal()
        {
            this.health += 10*intelligence;
        }
        public void Heal(object target)
        {
            Human ally = target as Human;
            if (ally == null)
            {
                System.Console.WriteLine("Can't heal nothing!");
            }
            else
            {
                ally.health += 5*intelligence;
                System.Console.WriteLine("{0} heals {1} for {2} HP", this.name, ally.name, 5*this.intelligence);
            }
        }
        public void Fireball(object target)
        {
            Human enemy = target as Human;
            if (enemy == null)
            {
                System.Console.WriteLine("Can't Attack an Object!");
            }
            else
            {
                int damage = rnd.Next(20,51);
                enemy.health -= damage;
                System.Console.WriteLine("{0} cast a fireball spell and dealt {1} damage to {2}",this.name, damage, enemy.name);
            }
        }


    }

}