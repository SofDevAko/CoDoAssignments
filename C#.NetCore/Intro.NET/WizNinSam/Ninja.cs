using System;

namespace WizNinSam
{
    public class Ninja : Human
    {
        public new int dexterity = 175;

        public Ninja(string name) : base(name)
        {

        }

        public void Drain_Life(object target)
        {
            Human enemy = target as Human;
            if (enemy == null)
            {
                System.Console.WriteLine("You can't drain from nothing!");
            }
            else
            {
                this.health += 10;
                System.Console.WriteLine("{0} drained 10 HP from {1} using his Dagger of Life Stealing", this.name, enemy.name);
            }
        }
        public void Get_Away()
        {
            this.health -= 15;
            System.Console.WriteLine("{0} fails to disappear in the shadows and loses 15 HP", this.name);
        }

    }
}