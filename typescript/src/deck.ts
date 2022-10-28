import { Card } from "./card";
import { Suit } from "./suit";
export class Deck {
  public cards: Array<Card> = [];

  constructor() {
    for (var suit in Object.keys(Suit)) {
      for (var rank = 1; rank < 14; rank++) {
        this.cards.push(new Card(rank, Object.values(Suit)[suit]));
      }
    }
  }
}
