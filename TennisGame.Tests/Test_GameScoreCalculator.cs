using System;
using TennisGame;
using Xunit;

namespace TestGame.Tests
{
    public class Test_GameScoreCalculator
    {
        readonly string playerName1 = "Boris Becker 1";
        readonly string playerName2 = "Andy Murry 2";

        private void SetupGameAtDeuce(IPlayerGameScore gameScore1, IPlayerGameScore gameScore2)
        {
            // player 1 wins three points
            gameScore1.WonPoint(); // 15
            gameScore1.WonPoint(); // 30
            gameScore1.WonPoint(); // 40
            
            // player 2 wins three points
            gameScore2.WonPoint(); // 15
            gameScore2.WonPoint(); // 30
            gameScore2.WonPoint(); // 40
        }

        [Fact]
        public void ScoreDisplay_NoScoreIsShownAsZero()
        {
            var player1 = new Player(playerName1);
            var player2 = new Player(playerName2);

            var display = new GameScoreCalculator().ScoreDisplay(player1.GameScore, player2.GameScore);
            Assert.Equal("0-0", display);
        }

       [Fact]
        public void ScoreDisplay_Player2_Wins_DisplayPathTo15_40()
        {
            var player1 = new Player(playerName1);
            var player2 = new Player(playerName2);

            player1.GameScore.WonPoint();
            var display = new GameScoreCalculator().ScoreDisplay(player1.GameScore, player2.GameScore);
            Assert.Equal("15-0", display);

            player2.GameScore.WonPoint();
            display = new GameScoreCalculator().ScoreDisplay(player1.GameScore, player2.GameScore);
            Assert.Equal("15-15", display);

            player2.GameScore.WonPoint();
            player2.GameScore.WonPoint();
            display = new GameScoreCalculator().ScoreDisplay(player1.GameScore, player2.GameScore);
            Assert.Equal("15-40", display);
        }

        [Fact]
        public void ScoreDisplay_Player1_Wins_DisplayPathTo15_40()
        {
            var gameScore1 = new Player(playerName1).GameScore;
            var gameScore2 = new Player(playerName2).GameScore;

            gameScore2.WonPoint();
            var display = new GameScoreCalculator().ScoreDisplay(gameScore1, gameScore2);
            Assert.Equal("0-15", display);

            gameScore1.WonPoint();
            display = new GameScoreCalculator().ScoreDisplay(gameScore1, gameScore2);
            Assert.Equal("15-15", display);

            gameScore1.WonPoint();
            gameScore1.WonPoint();
            display = new GameScoreCalculator().ScoreDisplay(gameScore1, gameScore2);
            Assert.Equal("40-15", display);
        }

        [Fact]
        public void ScoreDisplay_DisplayDeuce()
        {
            var gameScore1 = new Player(playerName1).GameScore;
            var gameScore2 = new Player(playerName2).GameScore;

            var display = new GameScoreCalculator().ScoreDisplay(gameScore1, gameScore2);
            Assert.Equal("0-0", display);

            SetupGameAtDeuce(gameScore1, gameScore2);

            display = new GameScoreCalculator().ScoreDisplay(gameScore1, gameScore2);
            Assert.Equal("Deuce", display);

        }

        [Fact]
        public void ScoreDisplay_DisplayAdvantagePlayerName()
        {
            var gameScore1 = new Player(playerName1).GameScore;
            var gameScore2 = new Player(playerName2).GameScore;

            SetupGameAtDeuce(gameScore1, gameScore2);
            gameScore2.WonPoint(); // Advantage player 2
            

            var display = new GameScoreCalculator().ScoreDisplay(gameScore1, gameScore2);
            Assert.Equal(string.Format("Advantage {0}", playerName2), display);

        }

        [Fact]
        public void ChooseWinner_ByAdvantageWin()
        {
            var player1 = new Player(playerName1);
            var player2 = new Player(playerName2);

            SetupGameAtDeuce(player1.GameScore, player2.GameScore);

            player2.GameScore.WonPoint(); // Advantage player 2
            player2.GameScore.WonPoint(); // Won
            
            var winner = new GameScoreCalculator().ChooseWinner(player1, player2);
            Assert.Equal(winner.Name, playerName2);
        }

        [Fact]
        public void ChooseWinner_Slot1_ByOutrightWin()
        {
            var player1 = new Player(playerName1);
            var player2 = new Player(playerName2);

            // palyer 1 wins three points
            player2.GameScore.WonPoint(); // 15      
            
            player1.GameScore.WonPoint(); // 15
            player1.GameScore.WonPoint(); // 30
            player1.GameScore.WonPoint(); // 40
            player1.GameScore.WonPoint(); // Won
            
            
            var winner = new GameScoreCalculator().ChooseWinner(player1, player2);
            Assert.Equal(winner.Name, playerName1);
        }

        [Fact]
        public void ChooseWinner_Slot2_ByOutrightWin()
        {
            var player1 = new Player(playerName1);
            var player2 = new Player(playerName2);

            // palyer 1 wins three points
            player1.GameScore.WonPoint(); // 15      
            
            player2.GameScore.WonPoint(); // 15
            player2.GameScore.WonPoint(); // 30
            player2.GameScore.WonPoint(); // 40
            player2.GameScore.WonPoint(); // Won
            
            var winner = new GameScoreCalculator().ChooseWinner(player1, player2);
            Assert.Equal(winner.Name, playerName2);
        }

        [Fact]
        public void ChooseWinner_NoWinner_ReturnsNull()
        {
            var player1 = new Player(playerName1);
            var player2 = new Player(playerName2);

            // palyer 1 wins three points
            player1.GameScore.WonPoint(); // 15      
            
            player2.GameScore.WonPoint(); // 15
            player2.GameScore.WonPoint(); // 30
            player2.GameScore.WonPoint(); // 40       
            
            var winner = new GameScoreCalculator().ChooseWinner(player1, player2);
            Assert.Null(winner);
        }

        [Fact]
        public void HasScoreToDisplay_NoPointsInGame_ReturnsFalse()
        {
            var player1 = new Player(playerName1);
            var player2 = new Player(playerName2);

            var scoreToDisplay = new GameScoreCalculator().HasScoreToDisplay(player1.GameScore, player2.GameScore);
            Assert.False(scoreToDisplay);
        }

        [Fact]
        public void HasScoreToDisplay_AnyPointInGame_ReturnsTrue()
        {
            var player1 = new Player(playerName1);
            var player2 = new Player(playerName2);

            player2.GameScore.WonPoint();

            var scoreToDisplay = new GameScoreCalculator().HasScoreToDisplay(player1.GameScore, player2.GameScore);
            Assert.True(scoreToDisplay);
        }
    }
}