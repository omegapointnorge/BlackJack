package no.itverket;

import java.util.ArrayDeque;
import java.util.Queue;

class Deck {
    Queue<Card> cards;

    Deck() {
        cards = new ArrayDeque<>();
        for (Suit suit : Suit.values()) {
            for (int i = 1; i < 14; i++) {
                cards.offer(new Card(suit, i));
            }
        }
    }
}
