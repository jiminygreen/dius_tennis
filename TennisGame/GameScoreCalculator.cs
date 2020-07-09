using System;

namespace TennisGame
{
    interface IGameScoreCalculator
    {
        IPlayer ChooseWinner(IPlayer player1, IPlayer player2);

        bool HasScoreToDisplay(IPlayerGameScore gameScore1, IPlayerGameScore gameScore2);

        string ScoreDisplay(IPlayerGameScore gameScore1, IPlayerGameScore gameScore2);

    }
 
    public class GameScoreCalculator : IGameScoreCalculator
    {

        private bool DidWinFirstSlot(IPlayerGameScore gameScore1, IPlayerGameScore gameScore2)
        {
            // More than 3 points translates to above 40. So you can win if you have 2 more points than the other player
            return (gameScore1.Points > 3 && (Math.Abs(gameScore1.Points - gameScore2.Points) >= 2)) ? true : false;
        }

        //Work out if someone one the game. If someone did. Return that winner. If no one won, return null
        public IPlayer ChooseWinner(IPlayer player1, IPlayer player2)
        {
            // Check if the first player won
            if (DidWinFirstSlot(player1.GameScore, player2.GameScore))
                return player1;
            // if the first player didn't win. check if the second player won
            if (DidWinFirstSlot(player2.GameScore, player1.GameScore))
                return player2;

            // if neither won then return null
            return null;
        }

        public bool HasScoreToDisplay(IPlayerGameScore gameScore1, IPlayerGameScore gameScore2)
        {
            return (gameScore1.Points > 0 || gameScore2.Points > 0);
        }

        public string ScoreDisplay(IPlayerGameScore gameScore1, IPlayerGameScore gameScore2)
        {
            // 1 point = 15
            // 2 point = 30
            // 3 points = 40
            if (gameScore1.Points < 3 || gameScore2.Points < 3)
                return string.Format("{0}-{1}", gameScore1.PointsAsString(), gameScore2.PointsAsString());

            // if both players have scored more than 3 points and there is a 1 point gap, then it is an advantage to the higher number
            if ((gameScore1.Points >= 3 && gameScore2.Points >= 3) && (Math.Abs(gameScore1.Points - gameScore2.Points) == 1))
            {
                var advantageGoesTo = gameScore1.Points > gameScore2.Points ? gameScore1 : gameScore2;
                return string.Format("Advantage {0}", advantageGoesTo.Player.Name);
            }

            return "Deuce";
        }
    }
}
