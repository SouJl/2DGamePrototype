using PixelGame.Configs;
using PixelGame.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Model
{
    public class PatrolAI : ILogicAI<List<Transform>>
    {
        private List<Transform> _path;
        private float _nextWayPointDistance;
        private int _currentWayPoint;
        private float _updateFrameRate;
        private bool _reachedEndOfPath;


        public float NextWayPointDistance { get => _nextWayPointDistance; }

        public int CurrentWayPoint { get => _currentWayPoint; }

        public float UpdateFrameRate { get => _updateFrameRate; }

        public bool ReachedEndOfPath { get => _reachedEndOfPath; set => _reachedEndOfPath = value; }

        public List<Transform> Path { get => _path; }

        public PatrolAI(AIConfig config, List<Transform> patrolWayPoints) 
        {
            _updateFrameRate = config.UpdateFrameRate;
            _nextWayPointDistance = config.NextWayPointDistance;
            _path = patrolWayPoints;

            _currentWayPoint = 0;
        }

        public Vector2 CalculatePath(Vector2 fromPosition)
        {
            if (Path.Count == 0) return Vector2.zero;

            ReachedEndOfPath = false;

            if (_currentWayPoint >= _path.Count)
            {
                ReachedEndOfPath = true;
                return Vector2.zero;
            }

            Vector2 direction = ((Vector2)_path[_currentWayPoint].position - fromPosition).normalized;

            float distance = Vector2.Distance(fromPosition, _path[_currentWayPoint].position);

            if (distance < NextWayPointDistance)
            {
                _currentWayPoint++;
            }

            return direction;
        }

        public void OnPathComplete(List<Transform> wayPoints)
        {
            if(wayPoints != null)
                _currentWayPoint = 0;
        }
    }
}
