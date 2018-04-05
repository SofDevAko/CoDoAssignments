using System;

namespace WizNinSam
{
    public class Human{

    
    public string name;
    public int health {get;set;}
    public int strength {get;set;}
    public int intelligence {get;set;}
    public int dexterity {get;set;}

    public Human(string person = "")
    {
        name = person;
        strength = 3;
        intelligence = 3;
        dexterity = 3;
        health = 100;
    }
    // public Human(string person="", int str=3, int intel=3, int dex=3, int hp=100)
    // {
    //     name = person;
    //     strength = str;
    //     intelligence = intel;
    //     dexterity = dex;
    //     health = hp;
    // }

    public void attack(object obj)
    {
        Human enemy = obj as Human;
        if (enemy == null)
        {
            System.Console.WriteLine("Failed Attack on 'Nothing'!");
        }
        else
        {
            enemy.health -= strength *5;
            System.Console.WriteLine("{0} attacked {1} and caused {2} damage", name, enemy.name, this.strength*5);
        }
    }

    }
    
}