namespace TennisGame
{

    public class Player
    {
        public string Name { get { return _name; } }
        private string _name;

        public Player(string name)
        {
            _name = name;
            
        }


    }
}