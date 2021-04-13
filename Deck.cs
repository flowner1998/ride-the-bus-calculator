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

        public void setCards(List<Card> cards)
        {
            this.Cards = cards;
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

        public void Shuffle(ThreadSafeRandom random, int shuffleAmount, int leaveIntact)
        {
            while(shuffleAmount > 1)
            {
                int swapA = (random.Next() % (this.Cards.Count - leaveIntact)) + leaveIntact;
                int swapB = (random.Next() % (this.Cards.Count - leaveIntact)) + leaveIntact;

                Card swapCard = this.Cards[swapA];
                this.Cards[swapA] = this.Cards[swapB];
                this.Cards[swapB] = swapCard;

                shuffleAmount--;
            }
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