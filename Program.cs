using System;

namespace ride_the_bus_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Parameters parameters = new Parameters(7, 1000, 1000);
            parameters.SetParameters();
            Console.WriteLine(parameters);
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
