namespace TennisGame
{

    public interface IPlayer
    {
        string Name { get; }
        IPlayerGameScore GameScore { get; }
        IPlayerSetScore SetScore { get; }

    }

    public class Player : IPlayer
    {
        public string Name { get { return _name; } }
        private string _name;
        public IPlayerGameScore GameScore { get { return _gameScore; } }
        private IPlayerGameScore _gameScore;
        public IPlayerSetScore SetScore { get { return _setScore; } }
        private IPlayerSetScore _setScore;

        public Player(string name)
        {
            _name = name;
            _gameScore = new PlayerGameScore(this);
            _setScore = new PlayerSetScore(this);

        }


    }
}