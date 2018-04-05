namespace deckOfCards
{
    public class Card
    {
        
        public string suit = "";
        public string strval = "";
        public int val = 1;

        public Card(string sut, string stval, int value)
        {
            object card = (
                suit = sut,
                strval = stval,
                val = value
            );
        }
    }
}
