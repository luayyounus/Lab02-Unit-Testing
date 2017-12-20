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
            Assert.Equal("P2", Game.CheckCards("5", "Spades", "7", "Hearts"));
        }

        [Theory]
        [InlineData("K", "hearts", "6", "diamonds", "P1")]
        [InlineData("9", "diamonds", "8", "spades", "P1")]
        [InlineData("Q", "spades", "J", "hearts", "P1")]
        public void ReturnPlayerOneWinner(string p1Card, string p1Suit, string p2Card, string p2Suit, string expectedWinner)
        {
            Assert.Equal(expectedWinner, Game.CheckCards(p1Card, p1Suit, p2Card, p2Suit));
        }

        [Theory]
        [InlineData("K", "hearts", "A", "diamonds", "P2")]
        [InlineData("3", "diamonds", "7", "spades", "P2")]
        [InlineData("Q", "hearts", "Q", "spades", "P2")]
        public void ReturnPlayerTwoWinner(string p1Card, string p1Suit, string p2Card, string p2Suit, string expectedWinner)
        {
            Assert.Equal(expectedWinner, Game.CheckCards(p1Card, p1Suit, p2Card, p2Suit));
        }
    }
}
