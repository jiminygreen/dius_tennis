namespace TennisGame
{

    public class Player
    {
        public string Name { get { return _name; } }
        private string _name;
        public PlayerGameScore GameScore { get { return _gameScore; } }
        private PlayerGameScore _gameScore;

        public Player(string name)
        {
            _name = name;
            _gameScore = new PlayerGameScore(this);
            
        }


    }
}