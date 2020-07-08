using System;
using TennisGame;
using Xunit;

namespace TestGame.Tests
{
    public class Test_Match
    {
        readonly string playerName1 = "player 1";
        readonly string playerName2 = "player 2";

        [Fact]
        public void Score_ZeroSets_OnePoint_Player1()
        {
            var match = new Match(playerName1, playerName2);
            match.pointWonBy(playerName1);
            var score = match.score();
            Assert.Equal("0-0, 15-0", score);
            
        }

        [Fact]
        public void Score_ZeroSets_StraightGameWin_Player1()
        {
            var match = new Match(playerName1, playerName2);
            match.pointWonBy(playerName1);
            var score = match.score();
            Assert.Equal("0-0, 15-0", score);

            match.pointWonBy(playerName1);
            score = match.score();
            Assert.Equal("0-0, 30-0", score);

            match.pointWonBy(playerName1);
            score = match.score();
            Assert.Equal("0-0, 40-0", score);

            match.pointWonBy(playerName1);
            score = match.score();
            Assert.Equal("1-0", score);
            
        }

        private void SetupGameAtDeuce(Match match, string playerName1, string playerName2)
        {
            // player 1 wins three points
            match.pointWonBy(playerName1); // 15
            match.pointWonBy(playerName1); // 30
            match.pointWonBy(playerName1); // 40
            
            // player 2 wins three points
            match.pointWonBy(playerName2); // 15
            match.pointWonBy(playerName2); // 30
            match.pointWonBy(playerName2); // 40
        }

        [Fact]
        public void Score_ZeroSets_Deuce_NoGameWin_Player1()
        {
            var match = new Match(playerName1, playerName2);
            SetupGameAtDeuce(match, playerName1, playerName2);
            var score = match.score();
            Assert.Equal("0-0, Deuce", score);
        }

        
        [Fact]
        public void Score_ZeroSets_Advantage_and_GameWin_Player1()
        {
            var match = new Match(playerName1, playerName2);
            SetupGameAtDeuce(match, playerName1, playerName2);
            var score = match.score();
            Assert.Equal("0-0, Deuce", score);

            match.pointWonBy(playerName1);
            score = match.score();
            Assert.Equal(string.Format("0-0, Advantage {0}", playerName1), score);

            match.pointWonBy(playerName1);
            score = match.score();
            Assert.Equal("1-0", score);
        }
    }
}
