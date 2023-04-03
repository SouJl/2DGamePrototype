using System;
using System.Collections.Generic;
using UnityEngine;

namespace Root.PixelGame.Game.AI.Model
{
    internal class PatrolAIModel : BaseAIModel
    {
        private readonly IList<Transform> _wayPoints;

        private Transform _target;
        private int _currentPositionIndex;

        public PatrolAIModel(
            IAIConfig config,
            IList<Transform> wayPoints) : base(config)
        {
            _wayPoints
                = wayPoints ?? throw new ArgumentNullException(nameof(wayPoints));
        }

        public override void InitModel()
        {
            _target = GetNextWaypoint();
        }

        public override void DeinitModel()
        {
            _wayPoints.Clear();
            _target = default;
            _currentPositionIndex = default;
        }   

        public override Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            if (sqrDistance <= config.MinSqrDistance)
            {
                _target = GetNextWaypoint();
            }
            var direction = ((Vector2)_target.position - fromPosition).normalized;

            return direction;
        }

        private Transform GetNextWaypoint()
        {
            _currentPositionIndex = (_currentPositionIndex + 1) % _wayPoints.Count;
            return _wayPoints[_currentPositionIndex];
        }   
    }
}
