using System.Collections.Generic;

namespace Bussen
{
    class Card
    {
        private SuitEnum Suit;
        private ValueEnum Value;

        public Card(SuitEnum suit, ValueEnum value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public (SuitEnum, ValueEnum) GetCard()
        {
            return (this.Suit, this.Value);
        }

        public SuitEnum GetSuit()
        {
            return this.Suit;
        }

        public ValueEnum GetValue()
        {
            return this.Value;
        }
        

        override public string ToString()
        {
            return $"{this.Suit}{this.Value}";
        }
    }

    public enum SuitEnum
    {
        Spades,
        Clubs,
        Hearts,
        Diamonds
    }

    public enum ValueEnum
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
