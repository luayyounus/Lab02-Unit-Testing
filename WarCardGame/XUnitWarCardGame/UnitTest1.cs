using System;
using WarCardGame;
using Xunit;

namespace XUnitWarCardGame
{
    public class UnitTest1
    {
        [Fact]
        public void CheckWhichPlayerWinsTheCard()
        {
            // Check Cards Takes two String arrays representing a player [ Card , Suit ]
            Assert.Equal("P2", Game.CheckCards(new []{"5", "Spades"}, new []{"7", "Hearts"}));
        }

        [Theory]
        [InlineData("K", "hearts", "6", "diamonds", "P1")] // Data that will structure new Players string arrays to check against
        [InlineData("9", "diamonds", "8", "spades", "P1")]
        [InlineData("Q", "spades", "J", "hearts", "P1")]
        public void ReturnPlayerOneWinner(string p1Card, string p1Suit, string p2Card, string p2Suit, string expectedWinner)
        {
            // Creating String arrays with both [ Card , Suit ]
            Assert.Equal(expectedWinner, Game.CheckCards(new string[]{p1Card, p1Suit}, new string[]{p2Card, p2Suit}));
        }

        [Theory]
        [InlineData("K", "hearts", "A", "diamonds", "P2")] // Data that will structure new Players string arrays to check against
        [InlineData("3", "diamonds", "7", "spades", "P2")]
        [InlineData("Q", "hearts", "Q", "spades", "P2")]
        public void ReturnPlayerTwoWinner(string p1Card, string p1Suit, string p2Card, string p2Suit, string expectedWinner)
        {
            // Creating String arrays with both [ Card , Suit ]
            Assert.Equal(expectedWinner, Game.CheckCards(new string[] { p1Card, p1Suit }, new string[] { p2Card, p2Suit }));
        }
    }
}
