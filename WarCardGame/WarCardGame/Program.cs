using System;
using System.Linq;

namespace WarCardGame
{
    public static class Game
    {
        public static int CardsLeftPlayerOne = 52;
        public static int CardsLeftPlayerTwo = 52;

        public static string[] CardDeck = { "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };
        public static string[] CardSuit = { "hearts", "diamonds", "clubs", "spades" };

        public static int[] RandomCard()
        {
            Random random = new Random();
            int randomCard = random.Next(12);
            int randomSuit = random.Next(3);

            return new[] { randomCard, randomSuit };
        }

        public static string CheckCards(string[] playerOne, string[] playerTwo)
        {
            string a = playerOne[0];
            int cardOne = Array.FindIndex(CardDeck, c => c == playerOne[0]);
            int suitOne = Array.FindIndex(CardSuit, s => s == playerOne[1]);

            int cardTwo = Array.FindIndex(CardDeck, c => c == playerTwo[0]);
            int suitTwo = Array.FindIndex(CardSuit, s => s == playerTwo[1]);

            if (cardOne > cardTwo)
            {
                CardsLeftPlayerOne++;
                CardsLeftPlayerTwo--;

                return "P1";
            }

            if (cardTwo > cardOne)
            {
                CardsLeftPlayerTwo++; 
                CardsLeftPlayerOne--;

                return "P2";
            }

            if (suitOne > suitTwo)
            {
                Console.WriteLine("----------------------- WAAAAAAAAR! --------------------------");
                CardsLeftPlayerOne += 2;
                CardsLeftPlayerTwo -= 2;
                return "P1";
            }

            Console.WriteLine("----------------------- WAAAAAAAAR! --------------------------");
            CardsLeftPlayerOne -= 2;
            CardsLeftPlayerTwo += 2;
            return "P2";
        }

        public static void Draw()
        {
            int[] randomCard1 = RandomCard();
            int[] randomCard2 = RandomCard();

            string[] playerOne = new string[] {CardDeck[randomCard1[0]], CardSuit[randomCard1[1]]};
            string[] playerTwo = new string[] {CardDeck[randomCard2[0]], CardSuit[randomCard2[1]]};

            Console.WriteLine("  P1: Cards Left ({0})   --->   {1} {2} VS {3} {4}   <---   P2: Cards Left ({5})",
                                CardsLeftPlayerOne, playerOne[0], playerOne[1],
                                playerTwo[0], playerTwo[1], CardsLeftPlayerTwo);

            CheckCards(playerOne, playerTwo);

            Console.ReadLine();
        }

        public static void StartGame()
        {
            Console.WriteLine("\n----------------------- The game has just started! --------------------------" +
                              "\nEach player has 52 Cards, the first one who runs out of Cards loses the game" +
                              "\n---------------- CLICK ENTER TO DRAW A CARD FOR BOTH PLAYERS ---------------- ");
            Console.ReadLine();

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

                Draw();
            }

            Console.WriteLine("Thanks for watching two random players playing WAR!");
            Console.Read();
        }

        public static void Main(string[] args)
        {
            StartGame();
        }
    }
}
