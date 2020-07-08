using System;
using TennisGame;
using Xunit;

namespace TestGame.Tests
{
    public class Test_SetScoreCalculator
    {
        readonly string playerName1 = "Boris Becker 1";
        readonly string playerName2 = "Andy Murry 2";

       [Fact]
        public void ScoreDisplay_Player2_Wins_DisplayPathTo15_40()
        {
            var setScore1 = new PlayerSetScore(new Player(playerName1));
            var setScore2 = new PlayerSetScore(new Player(playerName2));

            setScore1.WonGame();

            var display = new SetScoreCalculator().ScoreDisplay(setScore1, setScore2);
            Assert.Equal("1-0", display);

            setScore1.WonGame();

            display = new SetScoreCalculator().ScoreDisplay(setScore1, setScore2);
            Assert.Equal("2-0", display);

            setScore1.WonGame();

            display = new SetScoreCalculator().ScoreDisplay(setScore1, setScore2);
            Assert.Equal("3-0", display);
        }
    }
}