using System;

namespace TennisGame
{
    public class Match
    {
        Player _player1;
        Player _player2;

        private SetScoreCalculator _setScoreCalculator;
        private GameScoreCalculator _gameScoreCalculator;
        private MatchScoreCalculator _matchScoreCalculator;

        public Match(string playerName1, string playerName2)
        {
            _player1 = new Player(playerName1);
            _player2 = new Player(playerName2);

            _setScoreCalculator = new SetScoreCalculator();
            _gameScoreCalculator = new GameScoreCalculator();
            _matchScoreCalculator = new MatchScoreCalculator();
        }

        public void pointWonBy(string playerName)
        {
            // find the player
            var player = getPlayer(playerName);
            //var loserGameScore = getGameScoreForLoser(playerName);

            // add one to there score
            player.GameScore.WonPoint();

            var player_GameWinner = _gameScoreCalculator.ChooseWinner(_player1, _player2);

            // If not null then the game was won. Increament the game count in the Set
            if (null != player_GameWinner)
            {
                _player1.GameScore.Reset();
                _player2.GameScore.Reset();
                player.SetScore.WonGame();
            }
        }

        // Display the score to the caller
        public string score()
        {
            Player matchWinner = _matchScoreCalculator.ChooseWinner(_player1, _player2);
            if (null != matchWinner)
            {
                return string.Format("Match won by: {0}", matchWinner.Name);
            }

            var hasGameScoreToDisplay = new GameScoreCalculator().HasScoreToDisplay(_player1.GameScore, _player2.GameScore);
            if (hasGameScoreToDisplay)
            {
                return string.Format("{0}, {1}",
                 _setScoreCalculator.ScoreDisplay(_player1.SetScore, _player2.SetScore),
                 _gameScoreCalculator.ScoreDisplay(_player1.GameScore, _player2.GameScore)
                );
            }

            return _setScoreCalculator.ScoreDisplay(_player1.SetScore, _player2.SetScore);

        }

        // Return 
        public bool DidPlayerWinMatch(string playerName)
        {
            var player = getPlayer(playerName);
            var winner = _matchScoreCalculator.ChooseWinner(_player1, _player2);

            return (winner.Name == player.Name);
        }

        private Player getPlayer(string playerName)
        {
            if (this._player1.Name == playerName)
                return this._player1;

            return this._player2;
        }
    }
}
