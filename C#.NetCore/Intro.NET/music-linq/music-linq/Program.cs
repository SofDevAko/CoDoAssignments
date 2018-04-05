using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?

            // var first = Artists.Where(a => a.Hometown=="Mount Vernon");
            // foreach(var i in first)
            // {
            // System.Console.WriteLine(i.ArtistName);
            // System.Console.WriteLine(i.RealName);
            // System.Console.WriteLine(i.Age);
            // }

            //Who is the youngest artist in our collection of artists?
            // var second = Artists.OrderBy(a => a.Age).First();
            
            // System.Console.WriteLine(second.ArtistName);
            // System.Console.WriteLine(second.RealName);
            // System.Console.WriteLine(second.Age);
            
            //Display all artists with 'William' somewhere in their real name
            // var third = Artists.Where(a => a.RealName.Contains("William"));
            
            // foreach(var i in third)
            // {
            //     System.Console.WriteLine(i.ArtistName);
            //     System.Console.WriteLine(i.RealName);
            // }

            //Display the 3 oldest artist from Atlanta

            // var fourth = Artists.Where(i => i.Hometown == "Atlanta").OrderByDescending(a => a.Age).Take(3);
            
            // foreach(var i in fourth)
            // {
            //     System.Console.WriteLine(i.ArtistName);
            //     System.Console.WriteLine(i.RealName);
            //     System.Console.WriteLine(i.Age);
            // }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            var fifth = Groups.Select(a => a.GroupName).Except();
            
            foreach(var i in fifth)
            {
                System.Console.WriteLine(i.ArtistName);
                System.Console.WriteLine(i.RealName);
                System.Console.WriteLine(i.Age);
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
