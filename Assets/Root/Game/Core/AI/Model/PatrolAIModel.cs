using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Root.PixelGame.Game.AI.Model
{
    internal class PatrolAIModel : BaseAIModel
    {
        private readonly IList<Transform> _wayPoints;

        private Stack<Transform> _stackPoints;

        private Transform _target;


        public PatrolAIModel(
            IAIConfig config,
            IList<Transform> wayPoints) : base(config)
        {
            _wayPoints
                = wayPoints ?? throw new ArgumentNullException(nameof(wayPoints));

            FillWaypointStack(_wayPoints);
        }

        public override void InitModel()
        {
            _target = GetNextWaypoint();
        }

        public override void DeinitModel()
        {
            _wayPoints.Clear();
            _stackPoints.Clear();
            _target = default;
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
