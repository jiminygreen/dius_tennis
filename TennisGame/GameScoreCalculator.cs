using System;

namespace TennisGame
{

    public class GameScoreCalculator
    {

        private bool DidWinFirstSlot(PlayerGameScore gameScore1, PlayerGameScore gameScore2)
        {
            return (gameScore1.Points > 3 && (Math.Abs(gameScore1.Points - gameScore2.Points) >= 2)) ? true : false;
        }

        //Work out if someone one the game. If someone did. Return that winner. If no one won, return null
        public Player ChooseWinner(Player player1, Player player2)
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

        public bool HasScoreToDisplay(PlayerGameScore gameScore1, PlayerGameScore gameScore2)
        {
            return (gameScore1.Points > 0 || gameScore2.Points > 0);
        }

        public string ScoreDisplay(PlayerGameScore gameScore1, PlayerGameScore gameScore2)
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
