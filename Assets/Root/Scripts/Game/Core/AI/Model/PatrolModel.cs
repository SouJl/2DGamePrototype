using PixelGame.Components.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PixelGame.Game.AI.Model
{
    internal class PatrolModel
    {
        private readonly IList<Transform> _wayPoints;
        private readonly float _minSqrDistance;

        private Stack<Transform> _stackPoints;
        private Transform _target;

        public PatrolModel(
            IList<Transform> wayPoints,
            float minSqrDistance)
        {
            _wayPoints
                = wayPoints ?? throw new ArgumentNullException(nameof(wayPoints));

            _minSqrDistance = minSqrDistance;

            FillWaypointStack(_wayPoints);
        }

        public  void InitModel()
        {
            _target = GetNextWaypoint();
        }

        public  void DeinitModel()
        {
            _wayPoints.Clear();
            _stackPoints.Clear();
            _target = default;
        }

        public  Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            if (sqrDistance <= _minSqrDistance)
            {
                _target = GetNextWaypoint();
            }
            var direction = ((Vector2)_target.position - fromPosition).normalized;

            return direction;
        }

        private Transform GetNextWaypoint()
        {
            if (!_stackPoints.Any())
            {
                FillWaypointStack(_wayPoints, true);
            }
            return _stackPoints.Pop();
        }

        private void FillWaypointStack(IList<Transform> wayPoints, bool isReverse = false)
        {
            _stackPoints ??= new Stack<Transform>();
            _stackPoints.Clear();
            if (isReverse) wayPoints = wayPoints.Reverse().ToList();
            foreach (var point in wayPoints)
            {
                _stackPoints.Push(point);
            }
        }
    }
}
