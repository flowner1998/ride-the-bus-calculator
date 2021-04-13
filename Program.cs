using System;

namespace ride_the_bus_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the bussize
            int bussize;
            Console.Write("Give the bussize: ");
            if ( !int.TryParse(Console.ReadLine(), out bussize) ) {
                Console.WriteLine("Didn't supply a valid integer. Exiting.");
                return;
            }
            Console.WriteLine();

            // read the Shuffle amount
            int shuffleAmount;
            Console.Write("Give the shuffle amount: ");
            if ( !int.TryParse(Console.ReadLine(), out shuffleAmount) ) {
                Console.WriteLine("Didn't supply a valid integer. Exiting.");
                return;
            }
            Console.WriteLine();

            // Read the testsize
            int testSize;
            Console.Write("Give the amount of tests to perform: ");
            if ( !int.TryParse(Console.ReadLine(), out testSize) ) {
                Console.WriteLine("Didn't supply a valid integer. Exiting.");
                return;
            }
            Console.WriteLine();

            
        }
    }
}
