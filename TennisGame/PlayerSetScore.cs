namespace TennisGame
{
    public class PlayerSetScore
    {
        public int Games { get { return _games; } }
        int _games = 0;

        public Player Player { get; }
        public PlayerSetScore(Player player)
        {
            Player = player;
        }

        public void WonGame()
        {
            _games++;
        }

        public string GamesAsString()
        {
           return _games.ToString();
        }

    }
}