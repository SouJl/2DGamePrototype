using Pathfinding;
using System;
using UnityEngine;

namespace PixelGame.Model.AIModels
{
    internal class PatrolAIModel
    {
        private Path _path;
        private float _minSqrDistance;

        private Transform[] _waypoints;
        private int _currentPathIndex;
        private int _currentPointIndex;

        public Action OnReachedEndOfPath { get; set; }

        public PatrolAIModel(Transform[] waypoints, float minSqrDistance)
        {
            _waypoints = waypoints;
            _minSqrDistance = minSqrDistance;
            _currentPointIndex = 0;
        }

        public Transform GetNextTarget()
        {
            if (_waypoints == null) return null;
            _currentPointIndex = (_currentPointIndex + 1) % _waypoints.Length;
            return _waypoints[_currentPointIndex];
        }


        public Transform GetClosestTarget(Vector2 fromPosition)
        {
            if (_waypoints == null) return null;
            var closestIndex = 0;
            var closestDistance = 0.0f;
            for (var i = 0; i < _waypoints.Length; i++)
            {
                var distance = Vector2.Distance(fromPosition,
                _waypoints[i].position);
                if (closestDistance > distance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }
            _currentPointIndex = closestIndex;
            return _waypoints[_currentPointIndex];
        }

        public void UpdatePath(Path p)
        {
            _path = p;
            _currentPathIndex = 0;
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            if (_path == null) return Vector2.zero;

            if (_currentPathIndex >= _path.vectorPath.Count)
            {
                OnReachedEndOfPath?.Invoke();
                return Vector2.zero;
            }

            var direction = ((Vector2)_path.vectorPath[_currentPathIndex] - fromPosition).normalized;

            var sqrDistance = Vector2.SqrMagnitude((Vector2)_path.vectorPath[_currentPathIndex] - fromPosition);

            if (sqrDistance <= _minSqrDistance)
            {
                _currentPathIndex++;
            }

            return direction;
        }

    }
}
