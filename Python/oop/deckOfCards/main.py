"""Deck of Cards assignment (Optional)"""
"""Create a deck of cards with all 52 cards in it and have deal and shuffle methods inside"""
class Card(object):
    def __init__(self, suit, value, id):
        self.suit = suit
        self.value = value
        self.id = id

class DeckOfCards(object):
    def __init__(self):
        self.card_deck = []
        suits = ["hearts", "spades", "clubs", "diamonds"]
        id = 1
        for suit in suits:
            for val in range(1,14):
                # tupleval = (val,suit)
                # card_deck.append(tupleval)
                card=Card(val, suit, id)
                self.card_deck.append(card)
                id += 1
        # print(self.card_deck)
    
    def deal(self):
        import random
        deal = random.choice(self.card_deck)
        print "Card is {} {} with id {}".format(deal.suit, deal.value, deal.id)
        

deck = DeckOfCards()
deck.deal()
# print(deck)