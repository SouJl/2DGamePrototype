using System;
using System.Collections.Generic;
using UnityEngine;

namespace Root.PixelGame.Game.AI
{
    internal class SimpleAI : BaseAI
    {
        private readonly IList<Transform> _wayPoints;

        private Transform _target;
        private int _currentPositionIndex;
     
        public SimpleAI(
            IAIConfig config, 
            IList<Transform> wayPoints) : base(config)
        {
            _wayPoints 
                = wayPoints ?? throw new ArgumentNullException(nameof(wayPoints));

            Init();
        }

        public override void Init()
        {
            _target = GetNextWaypoint();
        }

        public override void Deinit()
        {
            _wayPoints.Clear();
            _target = default;
            _currentPositionIndex = default;
        }

        public override Vector2 GetNewVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            if (sqrDistance <= _config.MinSqrDistance)
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
