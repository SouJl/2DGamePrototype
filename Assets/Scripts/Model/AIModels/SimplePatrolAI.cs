using PixelGame.Configs;
using UnityEngine;

namespace PixelGame.Model.AIModels
{
    public class SimplePatrolAI : AbstractAI
    {
        #region private Variables

        private Transform _target;

        private int _currentPointIndex;

        #endregion

        public SimplePatrolAI(AIConfig config) : base(config)
        {
            Init();
        }

        #region public Methods

        public override void Init()
        {
            _target = GetNextWaypoint();
        }

        public override void Deint()
        {
            return;
        }

        public override Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            if (sqrDistance <= Config.MinSqrDistance)
            {
                _target = GetNextWaypoint();
            }
            var direction = ((Vector2)_target.position - fromPosition).normalized;

            return direction;
        }

        public override void Update(float time)
        {
            return;
        }

        #endregion

        #region private Methods

        private Transform GetNextWaypoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % Config.waypoints.Length;
            return Config.waypoints[_currentPointIndex];
        }

        #endregion
    }
}
