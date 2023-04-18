using Pathfinding;
using Root.PixelGame.Components.AI;
using UnityEngine;

namespace Root.PixelGame.Game.AI.Model
{
    internal interface IPathAIModel
    {
        void UpdatePath(Path p);

        Vector2 CalculateVelocity(Vector2 fromPosition);
    }

    internal class StalkerAIModel : BaseAIModel, IPathAIModel
    {
        private int _currentPointIndex;

        public StalkerAIModel(IAIData data) : base(data)
        {
        }

        public override Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            if (path == null) return Vector2.zero;

            if (_currentPointIndex >= path.vectorPath.Count) return Vector2.zero;

            var direction = ((Vector2)path.vectorPath[_currentPointIndex] - fromPosition).normalized;

            var sqrDistance = Vector2.SqrMagnitude((Vector2)path.vectorPath[_currentPointIndex] - fromPosition);

            if (sqrDistance <= data.MinSqrDistance)
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
    }
}
