using System;
using System.Linq;

namespace WarCardGame
{
    public static class Game
    {
        public static string[] CardDeck = { "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A"};
        public static string[] CardSuit = {"hearts", "diamonds", "clubs", "spades"};

        public static string CheckCards(string playerOneCard, string playerOneSuit, 
                                        string playerTwoCard, string playerTwoSuit)
        {
            var cardOne = Array.IndexOf(CardDeck, playerOneCard.ToUpper());
            var suitOne = Array.IndexOf(CardSuit, playerOneSuit.ToLower());

            var cardTwo = Array.IndexOf(CardDeck, playerTwoCard.ToUpper());
            var suitTwo = Array.IndexOf(CardSuit, playerTwoSuit.ToLower());

            if (cardOne > cardTwo)
            {
                return "P1";
            }
            if (cardTwo > cardOne)
            {
                return "P2";
            }
            return suitOne > suitTwo ? "P1" : "P2";
        }

        public static void Main(string[] args)
        {
            
        }
    }
}
