using Pathfinding;
using Root.PixelGame.Components.AI;
using Root.PixelGame.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Root.PixelGame.Game.AI.Model
{
    internal interface ITargetedAIModel : IPathAIModel
    {
        event Action OnReachedEnd;
        ITargetSelector Target { get; }
        void ChangeTarget();
    }

    internal class PatrolAIModel : BaseAIModel, ITargetedAIModel
    {
        private readonly IList<Transform> _wayPoints;
        private readonly IList<Transform> _reversedWayPoints;
        private readonly ITargetSelector _target;
        private Stack<Transform> _stackPoints;

        private int _currentPointIndex;
        public ITargetSelector Target => _target;

        public event Action OnReachedEnd;

        private bool _changeState = true;

        public PatrolAIModel(
            IAIData data,
            IList<Transform> wayPoints,
            ITargetSelector target) : base(data)
        {
            _wayPoints
               = wayPoints ?? throw new ArgumentNullException(nameof(wayPoints));
            _target
                = target ?? throw new ArgumentNullException(nameof(target));

            _reversedWayPoints = _wayPoints.Reverse().ToList();

            FillWaypointStack();
        }

        public override void InitModel()
        {
            ChangeTarget();
            _currentPointIndex = 0;
        }

        public override void DeinitModel()
        {
            _target.ChangeTarget(default);
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

            if (sqrDistance < data.MinSqrDistance)
            {
                _currentPointIndex++;
            }

            return direction;
        }

        public void UpdatePath(Path p)
        {
            path = p;
            _currentPointIndex = 0;
        }

        private Transform GetNextWaypoint()
        {
            if (!_stackPoints.Any())
            {
                FillWaypointStack(_changeState);
                _changeState = !_changeState;
            }
            return _stackPoints.Pop();
        }

        private void FillWaypointStack(bool isReverse = false)
        {
            List<Transform> wayPoints;
            _stackPoints ??= new Stack<Transform>();
            _stackPoints.Clear();

            if (isReverse)
                wayPoints = _reversedWayPoints.ToList();
            else
                wayPoints = _wayPoints.ToList();

            for (int i = 1; i < wayPoints.Count; i++)
            {
                _stackPoints.Push(wayPoints[i]);
            }
        }

        public void ChangeTarget()
            => _target.ChangeTarget(GetNextWaypoint());
    }
}
