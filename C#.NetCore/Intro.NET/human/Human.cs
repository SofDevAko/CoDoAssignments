namespace human
{

    public class Human
    {
        public string name = "noone";
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;

        public Human(string n)
        {
            name = n;
        }
        public Human(string n, int st, int it, int dx, int hp)
        {
            name = n;
            strength = st;
            intelligence = it;
            dexterity = dx;
            health = hp;
        }
        public Human attack(object target)
        {
            if (target is Human)
            {
                Human enemy = target as Human;
                enemy.health -= 5*this.strength;
                System.Console.WriteLine("{0} attacked {1} and dealt {2} damage!", this.name, enemy.name, 5*this.strength);
                return enemy;
            }
            else
            {
                System.Console.WriteLine("{0} is not a target to attack!", target);
                return this;
            }
            
        }
    }   

}

