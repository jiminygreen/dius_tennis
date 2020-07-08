namespace TennisGame
{

    public class Player
    {
        public string Name { get { return _name; } }
        private string _name;
        public PlayerGameScore GameScore { get { return _gameScore; } }
        private PlayerGameScore _gameScore;
        public PlayerSetScore SetScore  { get { return _setScore; } }
        private PlayerSetScore _setScore;

        public Player(string name)
        {
            _name = name;
            _gameScore = new PlayerGameScore(this);
            _setScore = new PlayerSetScore(this);
            
        }


    }
}