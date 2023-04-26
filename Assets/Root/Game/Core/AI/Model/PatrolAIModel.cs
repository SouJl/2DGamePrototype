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
        private readonly ITargetSelector _target;
        private Stack<Transform> _stackPoints;

        private int _currentPointIndex;
        public ITargetSelector Target => _target;

        public event Action OnReachedEnd;

        public PatrolAIModel(
            IAIData data,
            IList<Transform> wayPoints,
            ITargetSelector target) : base(data)
        {
            _wayPoints
               = wayPoints ?? throw new ArgumentNullException(nameof(wayPoints));
            _target 
                = target ?? throw new ArgumentNullException(nameof(target));
            
            FillWaypointStack(_wayPoints);
        }

        public override void InitModel()
        {
            ChangeTarget();
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

        public void ChangeTarget() 
            => _target.ChangeTarget(GetNextWaypoint());
    }
}
