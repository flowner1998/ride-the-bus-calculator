using System;
using System.Collections.Generic;

namespace ride_the_bus_calculator
{
    class Deck
    {
        private List<Card> Cards;

        public Deck()
        {
            this.Cards = new List<Card>();
            Array suits = Enum.GetValues( typeof(SuitEnum) );
            foreach (SuitEnum suit in suits)
            {
                this.Cards.AddRange( this.CardsForSuit(suit) );
            }
        }

        private List<Card> CardsForSuit(SuitEnum suit)
        {
            List<Card> fullSuit = new List<Card>();
            Array values = Enum.GetValues( typeof(ValueEnum) );
            foreach (ValueEnum value in values)
            {
                fullSuit.Add(
                    new Card(suit, value)
                );
            }
            return fullSuit;
        }

        public List<Card> GetDeck()
        {
            return this.Cards;
        }

        public override string ToString()
        {
            string s = String.Join(
                ", ",
                this.Cards
            );
            return s;
        }
    }
}