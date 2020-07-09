using System;

namespace TennisGame
{
    public interface IMatchScoreCalculator
    {       
        IPlayer ChooseWinner(IPlayer player1, IPlayer player2);

    }

    public class MatchScoreCalculator : IMatchScoreCalculator
    {

        private bool DidWinFirstSlot(IPlayer player1, IPlayer player2)
        {
            return (player1.SetScore.Games >= 6 && (Math.Abs(player1.SetScore.Games - player2.SetScore.Games) >= 2)) ? true : false;
        }

        // return the winner of the match. If niether player has won, return null.
        public IPlayer ChooseWinner(IPlayer player1, IPlayer player2)
        {
            // Six games to win a match
            if (DidWinFirstSlot(player1, player2))
                return player1;

            if (DidWinFirstSlot(player2, player1))
                return player2;

            return null;
        }
    }
}

