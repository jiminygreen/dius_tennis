using System;
using TennisGame;
using Xunit;

namespace TestGame.Tests
{
    public class Test_MatchScoreCalculator
    {
        readonly string playerName1 = "ready player 1";
        readonly string playerName2 = "ready player 2";

       [Fact]
        public void Test_Player1WinsMatch_StrightWin()
        {
            var player1 = new Player(playerName1);
            var player2 = new Player(playerName2);
            
            //var match = new Match(playerName1, playerName2);

            player1.SetScore.WonGame(); // 1
            player1.SetScore.WonGame(); // 2
            player1.SetScore.WonGame(); // 3
            player1.SetScore.WonGame(); // 4
            player1.SetScore.WonGame(); // 5
            player1.SetScore.WonGame(); // 6

            var winner = new MatchScoreCalculator().ChooseWinner(player1, player2);
            Assert.Equal(winner.Name, playerName1);
        }
    }
}