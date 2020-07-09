using System;

namespace TennisGame
{
    public interface ISetScoreCalculator
    {
        IPlayerSetScore ChooseWinner(IPlayerSetScore setScore1, IPlayerSetScore setScore2);
        string ScoreDisplay(IPlayerSetScore setScore1, IPlayerSetScore setScore2);

    }

    public class SetScoreCalculator : ISetScoreCalculator
    {

        private bool IsFirstSlotWinner(IPlayerSetScore scoreSlot1, IPlayerSetScore scoreSlot2)
        {
            return (scoreSlot1.Games >= 6 && (Math.Abs(scoreSlot1.Games - scoreSlot2.Games) >= 2)) ? true : false;
        }

        //Work out if someone one the game. If someone did. Return that winner. If no one won, return null
        public IPlayerSetScore ChooseWinner(IPlayerSetScore setScore1, IPlayerSetScore setScore2)
        {
            // Check if the first player won
            if (IsFirstSlotWinner(setScore1, setScore2))
                return setScore1;
            // if the first player didn't win. check if the second player won
            if (IsFirstSlotWinner(setScore2, setScore1))
                return setScore2;

            return null;
        }

        public string ScoreDisplay(IPlayerSetScore setScore1, IPlayerSetScore setScore2)
        {
            return string.Format("{0}-{1}", setScore1.GamesAsString(), setScore2.GamesAsString());
        }
    }
}