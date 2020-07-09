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

        public void PlayerWinsGame(Match match, string playerName)
        {
            match.pointWonBy(playerName); // 15
            match.pointWonBy(playerName); // 30
            match.pointWonBy(playerName); // 40
            match.pointWonBy(playerName); // Won
        }

        public void PlayerWinsGames(int gameNumber, Match match, string playerName)
        {
            for(int i = 0; i < gameNumber; i++)
            {
                PlayerWinsGame(match, playerName);
            }
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

        [Fact]
        public void Score_BothPlayersWin_MultipleGames()
        {
            var match = new Match(playerName1, playerName2);
            PlayerWinsGames(3, match, playerName1);
            var score = match.score();
            Assert.Equal("3-0", score);

            PlayerWinsGames(3, match, playerName2);
            score = match.score();
            Assert.Equal("3-3", score);
        }

        [Fact]
        public void Score_PlayerMustWins_ByTwoGames()
        {
            var match = new Match(playerName1, playerName2);
            PlayerWinsGames(5, match, playerName1);
            var score = match.score();
            Assert.Equal("5-0", score);

            PlayerWinsGames(6, match, playerName2);
            score = match.score();
            Assert.Equal("5-6", score);

            PlayerWinsGames(1, match, playerName2);
            score = match.score();
            Assert.Equal(string.Format("Match won by: {0}", playerName2), score);
        }

        
        [Fact]
        public void Score_Player1_WinsSet_and_Match()
        {
            var match = new Match(playerName1, playerName2);
            PlayerWinsGames(5, match, playerName1);
            var score = match.score();
            Assert.Equal("5-0", score);

            
            PlayerWinsGames(1, match, playerName1);
            score = match.score();
            Assert.Equal(string.Format("Match won by: {0}", playerName1), score);
        }

        [Fact]
        public void DidPlayerWinMatch_Player1_WinsSet_and_Match()
        {
            var match = new Match(playerName1, playerName2);
            PlayerWinsGames(6, match, playerName1);
            
            Assert.True(match.DidPlayerWinMatch(playerName1));
        }

        [Fact]
        public void DidPlayerWinMatch_NoOneHasWonMatchYet()
        {
            var match = new Match(playerName1, playerName2);
            PlayerWinsGames(5, match, playerName1);
            
            Assert.False(match.DidPlayerWinMatch(playerName1));
        }

        [Fact]
        public void Score_GameTieBreak()
        {
            var match = new Match(playerName1, playerName2);
            PlayerWinsGames(6, match, playerName1);
            PlayerWinsGames(6, match, playerName2);


            var score = match.score();
            Assert.Equal("6-6", score);
            Assert.False(match.DidPlayerWinMatch(playerName1));

            match.pointWonBy(playerName2); // 0-1
            match.pointWonBy(playerName2); // 0-2
            match.pointWonBy(playerName2); // 0-3
            match.pointWonBy(playerName1); // 1-3
            score = match.score();
            Assert.Equal("6-6, 1-3", score);
            match.pointWonBy(playerName2); // 1-4
            match.pointWonBy(playerName2); // 1-5
            match.pointWonBy(playerName2); // 1-6 - Match won by player2
            
            score = match.score();
            Assert.Equal("Match won by: player 2", score);
            Assert.True(match.DidPlayerWinMatch(playerName2));
        }

    }
}
