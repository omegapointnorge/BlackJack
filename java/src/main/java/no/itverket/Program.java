package no.itverket;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Program {
    public static void main(String[] args) {
        final Deck deck = new Deck();
        final List<Card> hand = new ArrayList<>();

        final Scanner scanner = new Scanner(System.in);
        while (true) {
            System.out.println("Stand, Hit");
            final String read = scanner.nextLine();

            if (read.equals("Hit")) {
                final Card card = deck.cards.remove();
                hand.add(card);
                final int total = hand.stream().map(x -> Math.min(x.rank, 10)).reduce(0, Integer::sum);
                System.out.println(String.format("Hit with %s %s. Total is %s", card.suit, card.rank, total));
            } else if (read.equals("Stand")) {
                break;
            }
        }
    }
}
