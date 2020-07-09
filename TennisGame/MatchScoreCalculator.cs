using System;

namespace TennisGame
{

    public class MatchScoreCalculator
    {

        private bool DidWinFirstSlot(Player player1, Player player2)
        {
            return (player1.SetScore.Games >= 6 && (Math.Abs(player1.SetScore.Games - player2.SetScore.Games) >= 2)) ? true : false;
        }

        // return the winner of the match. If niether player has won, return null.
        public Player ChooseWinner(Player player1, Player player2)
        {
            // Six games to win a match
            if (player1.SetScore.Games >= 6)
                return player1;

            if (player2.SetScore.Games >= 6)
                return player2;

            return null;
        }
    }
}

