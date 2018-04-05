using System;
using System.Collections.Generic;
namespace deckOfCards
{
    public class Deck
    {
        List<Card> deck = new List<Card>(52);

        public Deck()
        {
            Reset();
        }
        public object Deal()
        {
            object topcard = deck[0];
            System.Console.WriteLine("Top card is: {0} of {1} with value of {2}",deck[0].strval,deck[0].suit,deck[0].val);
            deck.RemoveAt(0);
            return topcard;
        }
        public void Reset()
        {
            deck.Clear();
            string[] suitlist = {"Spades","Clubs","Diamonds","Hearts"};
            string[] strvallist = {"Ace","2","3","4","5","6","7","8","9","10","Jack", "Queen", "King"};
            foreach (string suit in suitlist){
                for (int i = 0; i < 13; i++)
                {
                deck.Add(new Card(suit, strvallist[i], i+1));
                }
            }
            for (int i = 0; i < deck.Count; i++)
            {
                System.Console.WriteLine("Card is: {0} of {1} with value of {2}",deck[i].strval,deck[i].suit,deck[i].val);
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < deck.Count; i++)
            {
                int num = rnd.Next(0, deck.Count);
                object temp = deck[i];
                deck[i] = deck[num];
                deck[num] = deck[i];
            }
            for (int i = 0; i < deck.Count; i++)
            {
                System.Console.WriteLine("Card is: {0} of {1} with value of {2}",deck[i].strval,deck[i].suit,deck[i].val);
            }
            System.Console.WriteLine(deck.Count);
        }
    }
    

}