using Pathfinding;
using PixelGame.Configs;
using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public class StalkerAI : ILogicAI
    {
        private Path _path;
        private Seeker _seeker;
        private float _nextWayPointDistance;
        private int _currentWayPoint;
        private float _updateFrameRate;

        private bool _reachedEndOfPath;

        public Path Path { get => _path; }

        public Seeker Seeker { get => _seeker; }

        public float NextWayPointDistance { get => _nextWayPointDistance; }

        public int CurrentWayPoint { get => _currentWayPoint; }

        public float UpdateFrameRate { get => _updateFrameRate; }

        public bool ReachedEndOfPath { get => _reachedEndOfPath; set => _reachedEndOfPath = value; }


        public StalkerAI(Seeker seeker, AIConfig config) 
        {
            _seeker = seeker;
            _updateFrameRate = config.UpdateFrameRate;
            _nextWayPointDistance = config.NextWayPointDistance;
        }

        public void OnPathComplete(Path path)
        {
            if (!path.error) 
            {
                _path = path;
                _currentWayPoint = 0;
            }
        }
 
        public Vector2 CalculatePath(Vector2 fromPosition)
        {
            if (_path == null) return Vector2.zero;

            ReachedEndOfPath = false;

            if (_currentWayPoint >= _path.vectorPath.Count)
            {
                ReachedEndOfPath = true;
                return Vector2.zero;
            }

            Vector2 direction = ((Vector2)_path.vectorPath[_currentWayPoint] - fromPosition).normalized;

            float distance = Vector2.Distance(fromPosition, _path.vectorPath[_currentWayPoint]);

            if (distance < NextWayPointDistance)
            {
                _currentWayPoint++;
            }

            return direction;
        }
    }
}
