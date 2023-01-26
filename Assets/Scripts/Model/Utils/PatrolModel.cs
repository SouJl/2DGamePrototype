using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Model.AIModels
{
    public class PatrolModel
    {
        private List<Transform> _wayPoints;

        public List<Transform> WayPoints { get => _wayPoints; }

        private int _currentPointIndex;
        public PatrolModel(List<Transform> wayPoints)
        {
            _wayPoints = wayPoints;
        }

        public Transform GetNextTarget()
        {
            if (_wayPoints == null) return null;
            _currentPointIndex = (_currentPointIndex + 1) % _wayPoints.Count;
            return _wayPoints[_currentPointIndex];
        }

        public Transform GetClosestTarget(Vector2 fromPosition)
        {
            if (_wayPoints == null) return null;

            var closestIndex = 0;
            var closestDistance = 0.0f;
            for (var i = 0; i < _wayPoints.Count; i++)
            {
                var distance = Vector2.Distance(fromPosition,
                _wayPoints[i].position);
                if (closestDistance > distance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }
            _currentPointIndex = closestIndex;
            return _wayPoints[_currentPointIndex];
        }
    }
}
