namespace TennisGame
{
    public interface IPlayerGameScore
    {
        int Points {get;}

        IPlayer Player { get; }

        void WonPoint();

        void Reset();

        string PointsAsString();


    }

    /// This class is in charge of the game score for an individual player. 
    // It knows the number of points scored and can convert a point (number to a display i.e. 40)
    public class PlayerGameScore : IPlayerGameScore
    {
        public int Points { get { return _points; } }
        int _points = 0;

        public IPlayer Player { get; }
        public PlayerGameScore(IPlayer player)
        {
            Player = player;
        }

        public void WonPoint()
        {
            _points++;
        }

        public void Reset()
        {
            _points = 0;
        }

        public string PointsAsString()
        {
            var result = string.Empty;
            switch (_points)
            {
                case 0:
                    result = "0";
                    break;

                case 1:
                    result = "15";
                    break;

                case 2:
                    result = "30";
                    break;

                case 3:
                    result = "40";
                    break;

                case 4:
                    result = "Deuce";
                    break;

                case 5:
                    result = "Advantage";
                    break;

                default:
                    //throw new InvalidOperationException(string.Format("Points: {0} is not valid", _points.ToString()));
                    break;
            }

            return result;
        }

    }
}