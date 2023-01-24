using System.Collections.Generic;

namespace PixelGame.Utils
{
    public class WayPointsModel<T>
    {
        List<T> _wayPoints;
        public List<T> WayPoints { get => _wayPoints; private set => _wayPoints = value; }
        
        public WayPointsModel(List<T> waypoints)
        {
            WayPoints = waypoints;
        }        
    }
}
