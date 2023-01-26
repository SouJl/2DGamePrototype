using Pathfinding;
using PixelGame.Configs;
using PixelGame.Interfaces;
using System;
using UnityEngine;

namespace PixelGame.Model.Utils
{
    public class PathfinderModel: IPathfinderAI
    {
        private Path _path;
        private float _nextWayPointDistance;
        private int _currentWayPoint;
        private float _updateFrameRate;

        private bool _reachedEndOfPath;

        public Path Path { get => _path; }

        public float NextWayPointDistance { get => _nextWayPointDistance; }

        public int CurrentWayPoint { get => _currentWayPoint; }

        public float UpdateFrameRate { get => _updateFrameRate; }

        public bool ReachedEndOfPath { get => _reachedEndOfPath; set => _reachedEndOfPath = value; }
      
        public Action OnReachedEndOfPath { get; set; }

        public PathfinderModel(AIConfig config)
        {
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
                OnReachedEndOfPath?.Invoke();
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
