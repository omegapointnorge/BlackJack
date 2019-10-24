import unittest

from blackjack.deck import Deck

class DeckTest(unittest.TestCase):
    def setUp(self):
        self.deck = Deck()

    def test_should_have_52_cards(self):
        self.assertEqual(52, len(self.deck.cards))

    def test_should_have_4_distinct_suits(self):
        self.assertEqual(4, len(set([card.suit for card in self.deck.cards])))
