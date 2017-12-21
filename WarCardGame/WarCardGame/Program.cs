using System;

namespace WarCardGame
{
    public static class Game
    {
        // Giving 52 Cards to each player at the beginning of the Game
        public static int CardsLeftPlayerOne = 52;
        public static int CardsLeftPlayerTwo = 52;

        // Card deck sorted from 2 to Ace
        public static string[] CardDeck = { "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };
        // Card suit types valued in an ascendingly order
        public static string[] CardSuit = { "hearts", "diamonds", "clubs", "spades" };

        /// <summary>
        /// Randomize a card with Value and Suit then returns it as an array of 2.
        /// </summary>
        /// <returns>Return int array.</returns>
        public static int[] RandomCard()
        {
            Random random = new Random();
            int randomCard = random.Next(12);
            int randomSuit = random.Next(3);

            return new[] { randomCard, randomSuit };
        }

        // When two players match their Cards value a war happens to check for their Suits value
        public static string War()
        {
            // Drawing two cards every war for Player One - Game rules
            int[] playerOneRandomOne = RandomCard();
            int[] playerOneRandomTwo = RandomCard();
            int suitOne = playerOneRandomTwo[1];

            // Drawing two cards every war for Player Two - Game rules
            int[] playerTwoRandomOne = RandomCard();
            int[] playerTwoRandomTwo = RandomCard();
            int suitTwo = playerTwoRandomTwo[1];

            // Increase cards number by 2 for P1 and return as winner - Decrease P2 cards number by 2 
            if (suitOne > suitTwo)
            {
                CardsLeftPlayerOne += 2;
                CardsLeftPlayerTwo -= 2;
                return "P1";
            }

            // Increase cards number by 2 for P2 and return as winner - Decrease P1 cards number by 2 
            CardsLeftPlayerTwo += 2;
            CardsLeftPlayerOne -= 2;
            return "P2";
        }

        /// <summary>
        /// Battling between two players and returning who takes both cards (A war might happen).
        /// </summary>
        /// <param name="playerOne"></param>
        /// <param name="playerTwo"></param>
        /// <returns>Return Winner of the current Battle.</returns>
        public static string CheckCards(string[] playerOne, string[] playerTwo)
        {
            // Getting indices from Card's number and suit for later comparison
            int cardOne = Array.FindIndex(CardDeck, c => c == playerOne[0]);
            int cardTwo = Array.FindIndex(CardDeck, c => c == playerTwo[0]);

            // Card one is bigger than Card two - increment Player one stack of cards
            if (cardOne > cardTwo)
            {
                CardsLeftPlayerOne++;
                CardsLeftPlayerTwo--;

                return "P1";
            }

            // Card one is bigger than Card two - increment Player two stack of cards
            if (cardTwo > cardOne)
            {
                CardsLeftPlayerTwo++; 
                CardsLeftPlayerOne--;

                return "P2";
            }

            Console.WriteLine("\n---------------------------------- WAAAAAAAAR! ----------------------------------\n");
            
            // Declare War when two cards match values and return the winner
            return War();
        }

        // Both players draw once from their cards deck
        public static void Draw()
        {
            // Generating random cards
            int[] randomCard1 = RandomCard();
            int[] randomCard2 = RandomCard();

            // Construct two players with Card Value and Suit
            string[] playerOne = new string[] {CardDeck[randomCard1[0]], CardSuit[randomCard1[1]]};
            string[] playerTwo = new string[] {CardDeck[randomCard2[0]], CardSuit[randomCard2[1]]};

            // LIVE results of both players
            Console.WriteLine("  P1: Cards Left ({0})   --->   {1} {2} VS {3} {4}   <---   P2: Cards Left ({5})",
                                CardsLeftPlayerOne, playerOne[0], playerOne[1],
                                playerTwo[0], playerTwo[1], CardsLeftPlayerTwo);

            // Checking Players cards and returning the winner from every draw
            CheckCards(playerOne, playerTwo);

            Console.ReadLine();
        }

        /// <summary>
        /// Start game when the user runs the application. This method will check for cards left in every player's deck and draw new cards. 
        /// </summary>
        public static void StartGame()
        {
            Console.WriteLine("\n----------------------- The game has just started! --------------------------" +
                              "\nEach player has 52 Cards, the first one who runs out of Cards loses the game" +
                              "\n---------------- CLICK ENTER TO DRAW A CARD FOR BOTH PLAYERS ---------------- ");
            Console.ReadLine();

            // Checking if any player has ran out of cards to end the game
            while (true)
            {
                if (CardsLeftPlayerOne == 0)
                {
                    Console.WriteLine("Player Two Won!");
                    break;
                }
                if(CardsLeftPlayerTwo == 0)
                {
                    Console.WriteLine("Player One Won!");
                    break;
                }

                // Making a Draw for new cards
                Draw();
            }

            Console.WriteLine("Thanks for watching two random players playing WAR!");
            Console.Read();
        }

        /// <summary>
        /// Main Entry point for WarCardGame.cs
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            StartGame();
        }
    }
}
