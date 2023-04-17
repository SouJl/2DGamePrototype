using Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Root.PixelGame.Game.AI.Model
{
    internal interface ITargetedAIModel : IPathAIModel
    {
        event Action OnReachedEnd;
        Transform CurrentTarget { get; }
        void UpdateTarget();
    }

    internal class PatrolAIModel : BaseAIModel, ITargetedAIModel
    {
        private readonly IList<Transform> _wayPoints;

        private Stack<Transform> _stackPoints;

        private Transform _target;

        private int _currentPointIndex;

        public Transform CurrentTarget => _target;

        public event Action OnReachedEnd;

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
            if (path == null) return Vector2.zero;

            if (_currentPointIndex >= path.vectorPath.Count)
            {
                OnReachedEnd?.Invoke();
                return Vector2.zero;
            }

            var direction = ((Vector2)path.vectorPath[_currentPointIndex] - fromPosition).normalized;

            var sqrDistance = Vector2.SqrMagnitude((Vector2)path.vectorPath[_currentPointIndex] - fromPosition);

            if (sqrDistance < config.MinSqrDistance)
            {
                _currentPointIndex++;
            }

            return direction;
        }

        public void UpdatePath(Path p)
        {
            path = p;
            _currentPointIndex = 1;
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

        public void UpdateTarget()
        {
            _target = GetNextWaypoint();
        }
    }
}
