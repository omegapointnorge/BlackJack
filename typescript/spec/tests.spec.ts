import { describe, expect, test } from "@jest/globals";
import { Deck } from "../src/deck";

describe("Test deck", () => {
  test("Should have 52 cards", () => {
    expect(new Deck().cards.length).toBe(52);
  });

  test("Should have 4 distinct suits", () => {
    expect(new Set(new Deck().cards.map((card) => card.Suit)).size).toBe(4);
  });
});
