namespace TennisGame
{
    public interface  IPlayerSetScore
    {
        int Games { get; }
        IPlayer Player { get; }
        void WonGame();
        string GamesAsString();

    }

    public class PlayerSetScore : IPlayerSetScore
    {
        public int Games { get { return _games; } }
        int _games = 0;

        public IPlayer Player { get; }
        public PlayerSetScore(IPlayer player)
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