using System;

namespace TennisGame
{
    public class Match
    {
        Player _player1;
        Player _player2;

        
        public Match(string playerName1, string playerName2)
        {
            _player1 = new Player(playerName1);
            _player2 = new Player(playerName2);

        }

        public void pointWonBy(string playerName)
        {
           
        }

        public string score()
        {
           return string.Empty;
        }

        private Player getPlayer(string playerName)
        {
           return null;
        }
    }
}
