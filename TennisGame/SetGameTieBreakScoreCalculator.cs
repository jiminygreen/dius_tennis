
using System;
using TennisGame;

public class SetGameTieBreakScoreCalculator : IGameScoreCalculator
{
    private bool DidWinFirstSlot(IPlayerGameScore gameScore1, IPlayerGameScore gameScore2)
    {
        return (gameScore1.Points > 6 && (Math.Abs(gameScore1.Points - gameScore2.Points) >= 2)) ? true : false;
    }

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
        return string.Format("{0}-{1}", gameScore1.Points.ToString(), gameScore2.Points.ToString());
    }
}
