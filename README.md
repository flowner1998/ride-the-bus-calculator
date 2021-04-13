# ride-the-bus-calculator
A program to calculate the Ride The Bus drinking game best strategy.

## But why?
One night during a heavy game of playing Ride The Bus, I wondered what the best strategy would be. In our group we have the rule that if you call "Goalpost", meaning that you get the same face value that you're currently guessing, you will be instantly relieved from being in the bus. After some manual testing, we came to the conclusion: on average it takes about 20-30 cards before you get two cards in a row with the same face value.

To support these claims I was eager to test this out with a program. Unfortunately the most languages I know are uncompiled languages, which means they are slower by default.

That's why I gave C# a try for this project!

# Results
<pre>
-----PARAMETERS-----
Bus size: 7
Shuffle amount: 1000
Test size: 1000000
----------RESULTS----------
Calculations took 106232 ms
Minimum amount of cards: 1.
Maximum amount of cards: 209.
Average amount of cards: 16.
<pre>