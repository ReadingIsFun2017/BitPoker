﻿using System.Collections.Generic;
using System.Linq;
using BitPoker.Models.Cards;
using BitPoker.Logic.Extensions;

namespace BitPoker.Logic.Cards
{
    public class Deck : IDeck
    {
        public static readonly IReadOnlyList<Card> AllCards;

        private static readonly IEnumerable<CardType> AllCardTypes = new List<CardType>
                                                                         {
                                                                             CardType.Two,
                                                                             CardType.Three,
                                                                             CardType.Four,
                                                                             CardType.Five,
                                                                             CardType.Six,
                                                                             CardType.Seven,
                                                                             CardType.Eight,
                                                                             CardType.Nine,
                                                                             CardType.Ten,
                                                                             CardType.Jack,
                                                                             CardType.Queen,
                                                                             CardType.King,
                                                                             CardType.Ace
                                                                         };

        private static readonly IEnumerable<CardSuit> AllCardSuits = new List<CardSuit>
                                                                         {
                                                                             CardSuit.Club,
                                                                             CardSuit.Diamond,
                                                                             CardSuit.Heart,
                                                                             CardSuit.Spade
                                                                         };

        private readonly IList<Card> listOfCards;

        private int cardIndex;

        static Deck()
        {
            var cards = new List<Card>();
            foreach (var cardSuit in AllCardSuits)
            {
                foreach (var cardType in AllCardTypes)
                {
                    cards.Add(new Card(cardSuit, cardType));
                }
            }

            AllCards = cards.AsReadOnly();
        }

        public Deck()
        {
            this.listOfCards = AllCards.Shuffle().ToList();
            this.cardIndex = AllCards.Count;
        }

        public Card GetNextCard()
        {
            if (this.cardIndex == 0)
            {
                throw new InternalGameException("Deck is empty!");
            }

            this.cardIndex--;
            var card = this.listOfCards[this.cardIndex];
            return card;
        }
    }
}
