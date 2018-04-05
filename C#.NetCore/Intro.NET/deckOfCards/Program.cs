using System;

namespace deckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player akin = new Player("Akin");
            System.Console.WriteLine("========================");
            deck.Deal();
            System.Console.WriteLine("========================");
            deck.Deal();
             System.Console.WriteLine("========================");
           deck.Shuffle();
             System.Console.WriteLine("========================");
             deck.Reset();
              System.Console.WriteLine("========================");
             deck.Shuffle();
             akin.Draw(deck);
             for (int i =0; i<1; i++)
             {  
                 System.Console.WriteLine("{0} has the card: {1} of {2} in hand", akin.name , akin.hand[i].strval, akin.hand[i].suit);
             }
              System.Console.WriteLine("========================");
             deck.Shuffle();
              System.Console.WriteLine("========================");
              akin.Discard(0);
               System.Console.WriteLine("========================");
             deck.Shuffle();
            
        }
    }
}
