using System;
using TennisGame;
using Xunit;

namespace TestGame.Tests
{
    public class Test_PlayerGameScore
    {
        readonly string playerName1 = "ready player 1";

       [Fact]
        public void Test_StartingGameScoreIsEmpty()
        {
            var gameScore = new Player(playerName1).GameScore;
            var score = gameScore.PointsAsString();
            Assert.Equal("0", score);
        }

        [Fact]
        public void Test_SingleIncrementFromLoveTo15()
        {
            var gameScore = new Player(playerName1).GameScore;
            gameScore.WonPoint();
            var score = gameScore.PointsAsString();
            Assert.Equal("15", score);
        }

        [Fact]
        public void Test_IncrementFromLoveTo30()
        {
            var gameScore = new Player(playerName1).GameScore;
            gameScore.WonPoint();
            gameScore.WonPoint();
            var score = gameScore.PointsAsString();
            Assert.Equal("30", score);
        }

        [Fact]
        public void Test_IncrementFromLoveTo40()
        {
            var gameScore = new Player(playerName1).GameScore;
            gameScore.WonPoint();
            gameScore.WonPoint();
            gameScore.WonPoint();
            var score = gameScore.PointsAsString();
            Assert.Equal("40", score);
        }

        // [Fact]
        // public void Test_IncrementFromLoveToDeuce()
        // {
        //     var gameScore = new Player(playerName1).GameScore;
        //     gameScore.WonPoint();
        //     gameScore.WonPoint();
        //     gameScore.WonPoint();
        //     gameScore.WonPoint();
        //     var score = gameScore.PointsAsString();
        //     Assert.Equal("Deuce", score);
        // }

        // [Fact]
        // public void Test_IncrementFromLoveToAdvantage()
        // {
        //     var gameScore = new PlayerGameScore(new Player(playerName1));
        //     gameScore.WonPoint();
        //     gameScore.WonPoint();
        //     gameScore.WonPoint();
        //     gameScore.WonPoint();
        //     gameScore.WonPoint();
        //     var score = gameScore.PointsAsString();
        //     Assert.Equal("Advantage", score);
        // }
    }
}