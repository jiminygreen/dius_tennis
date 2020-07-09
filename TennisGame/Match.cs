using System;

namespace TennisGame
{
    public class Match
    {
        IPlayer _player1;
        IPlayer _player2;

        private ISetScoreCalculator _setScoreCalculator;
        private IGameScoreCalculator _gameScoreCalculator;
        private IMatchScoreCalculator _matchScoreCalculator;

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

            // add one to their score
            player.GameScore.WonPoint();

            // has someone won. Oh the excitment?
            var player_GameWinner = _gameScoreCalculator.ChooseWinner(_player1, _player2);

            // If not null then the game was won. Increament the game count in the Set
            if (null != player_GameWinner)
            {
                _gameScoreCalculator = new GameScoreCalculator();
                _player1.GameScore.Reset();
                _player2.GameScore.Reset();
                player.SetScore.WonGame();
            }

            if( hasSetMovedToTieBreak())
            {
                _gameScoreCalculator = new SetGameTieBreakScoreCalculator();
                _matchScoreCalculator = new MatchTieBreakerScoreCalculator();
            }
        }

        // Display the score to the caller
        public string score()
        {
            var matchWinner = _matchScoreCalculator.ChooseWinner(_player1, _player2);
            if (null != matchWinner)
            {
                return string.Format("Match won by: {0}", matchWinner.Name);
            }

            var hasGameScoreToDisplay = _gameScoreCalculator.HasScoreToDisplay(_player1.GameScore, _player2.GameScore);
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

            return (winner != null && winner.Name == player.Name);
        }

        private IPlayer getPlayer(string playerName)
        {
            if (this._player1.Name == playerName)
                return this._player1;

            return this._player2;
        }

        private bool hasSetMovedToTieBreak()
        {
            return (_player1.SetScore.Games >= 6 && _player2.SetScore.Games >= 6 );
            //&& _player1.GameScore.NoPoints && _player1.GameScore.NoPoints);
        }
    }
}
