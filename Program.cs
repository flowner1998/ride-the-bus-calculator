using System;
using System.Collections.Generic;
using System.Threading;

namespace ride_the_bus_calculator
{
    class Program
    {
        static List<int> results;

        static void Main(string[] args)
        {
            // Assign parameters for the program
            Parameters parameters = new Parameters(7, 1000, 1000);
            parameters.SetParameters();
            Console.WriteLine(parameters);

            // Make a ThreadSafe random instance
            ThreadSafeRandom rnd = new ThreadSafeRandom();

            // Make a list for the results
            results = new List<int>();

            // Loop over the amount of tests
            for (int n = 0; n < parameters.TestSize; n++)
            {
                // Start a thread for every test
                Thread t = new Thread(() => Program.Calculate(rnd, parameters));
                t.Start();
            }
        }


        static void Calculate(ThreadSafeRandom random, Parameters parameters){
            Deck deck = new Deck();
            deck.Shuffle(random, parameters.ShuffleAmount, 0);

            bool matched = false;
            int carry = 0;
            while( !matched)
            {
                // Shuffle the deck
                deck.Shuffle(random, parameters.ShuffleAmount, parameters.BusSize);

                // Get a list of the deck
                List<Card> currentDeck = deck.GetDeck();

                // Start looping through the deck. Lay down the bussize on the table and start at the next card.
                for (int i = 0; i < currentDeck.Count - parameters.BusSize; i++)
                {
                    int handcard = i + parameters.BusSize;
                    int tablecard = handcard - 1;
                    // Check if the card in the hand matches the card on the table on the last position (we changed the order for simplicity)
                    matched = ( currentDeck[tablecard].GetValue() == currentDeck[handcard].GetValue() );
                    
                    if ( matched )
                    {
                        // Add the amount of cards played to the result list. This is done by 
                        results.Add( i + carry );
                        return;
                    }
                }

                // Couldn't find a match in this deck. Carry the amount of cards played.
                carry = carry + currentDeck.Count - parameters.BusSize;

                // Set the last table card to the new table card and swap it with the hand card.
                Card currentLastCard = currentDeck[parameters.BusSize - 1];
                Card newLastTableCard = currentDeck[51];

                currentDeck[parameters.BusSize - 1]  = newLastTableCard;
                currentDeck[51] = currentLastCard;

                // Assign the new deck
                deck.setCards(currentDeck);
            }
        }
    }

    public class Parameters
    {
        public int BusSize;
        public int ShuffleAmount;
        public int TestSize;

        public Parameters(int bussize, int shuffleAmount, int testsize){
            this.BusSize = bussize; this.ShuffleAmount = shuffleAmount; this.TestSize = testsize;
        }

        public void SetParameters() {
            this.SetValue(ref this.BusSize, 1, "bus size");
            this.SetValue(ref this.ShuffleAmount, 10, "shuffle amount");
            this.SetValue(ref this.TestSize, 10, "test size");
        }

        private void SetValue(ref int item, int minValue, string desc)
        {
            bool test = false;
            string error = "";
            bool defaultValue = false;

            while ( !test ) {
                Console.Write($"Give the {desc} ({item}): ");

                // Read the input.
                string input = Console.ReadLine();

                // Check if the user wanted the default value.
                if( input.Equals("") ) {
                    Console.WriteLine("Using default value");
                    input = item.ToString();
                    defaultValue = true;
                }

                // Parse the value to an int
                bool isInt = int.TryParse(input, out item);
                
                // Check if value is integer.
                if ( !isInt && !defaultValue ){
                    error = "Please supply an integer.";
                    test = false;
                } else { test = true; }

                // Check if value is greater then 0.
                if ( item < minValue ) {
                    error = $"Please supply a value higher then {minValue}.";
                    test = false;
                } else { test = true; }

                // Give an error message if test is false and rerun.
                if ( !test ) {
                    Console.WriteLine(error);
                    Console.WriteLine();
                    continue;
                }

                break;
            }

            // Space out the values
            Console.WriteLine();
        }

        public override string ToString()
        {
            string s = String.Join(Environment.NewLine,
            "-----PARAMETERS-----",
            $"Bus size: {this.BusSize}",
            $"Shuffle amount: {this.ShuffleAmount}",
            $"Test size: {this.TestSize}"
            );
            return s;
        }
    }

    public class ThreadSafeRandom
    {
        private static readonly Random _global = new Random();
        [ThreadStatic] private static Random _local;

        public int Next()
        {
            if (_local == null)
            {
                lock (_global)
                {
                    if (_local == null)
                    {
                        int seed = _global.Next();
                        _local = new Random(seed);
                    }
                }
            }
            return _local.Next();
        }
    }
}
