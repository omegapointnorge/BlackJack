from collections import deque

from blackjack.suit import Suit
from blackjack.card import Card

class Deck:
    def __init__(self):
        self.cards = deque()

        for suit in Suit:
            for i in range(1, 14):
                self.cards.append(Card(rank=i, suit=suit))
