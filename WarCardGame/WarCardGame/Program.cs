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

        public static string CheckCards(string playerOneCard, string playerOneSuit, 
                                        string playerTwoCard, string playerTwoSuit)
        {
            int cardOne = Array.IndexOf(CardDeck, playerOneCard.ToUpper());
            int suitOne = Array.IndexOf(CardSuit, playerOneSuit.ToLower());

            int cardTwo = Array.IndexOf(CardDeck, playerTwoCard.ToUpper());
            int suitTwo = Array.IndexOf(CardSuit, playerTwoSuit.ToLower());

            if (cardOne > cardTwo)
            {
                CardsLeftPlayerOne++;
                CardsLeftPlayerTwo--;

                return "P1";
            }
            if (cardTwo > cardOne)
            {
                CardsLeftPlayerOne++;
                CardsLeftPlayerTwo--;

                return "P2";
            }

            if (suitOne > suitTwo)
            {
                CardsLeftPlayerOne += 2;
                CardsLeftPlayerTwo -= 2;
                return "P1";
            }

            CardsLeftPlayerOne -= 2;
            CardsLeftPlayerTwo += 2;
            return "P2";
        }

        public static void Main(string[] args)
        {

        }
    }
}
