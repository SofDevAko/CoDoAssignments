using System.Collections.Generic;

namespace deckOfCards
{
    public class Player
    {
        public string name = "";
        public List <Card> hand = new List<Card>();

        public Player(string plname)
        {
            name = plname;
        }

        public void Draw(Deck deck)
        {
            Card topcard = (Card)deck.Deal();
            hand.Add(topcard);
            
        }
        public Card Discard(int index)
        {
            Card discarded = new Card(hand[index].suit,hand[index].strval,hand[index].val);
            
            hand.RemoveAt(index);
            System.Console.WriteLine("Card is: {0} of {1} with value of {2}",discarded.strval,discarded.suit,discarded.val);

            return discarded;
        }
    }
}