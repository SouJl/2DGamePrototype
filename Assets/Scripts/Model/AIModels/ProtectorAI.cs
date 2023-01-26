using Pathfinding;
using PixelGame.Interfaces;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model.AIModels
{
    public class ProtectorAI : AbstractAIModel
    {
        private Seeker _seeker;
        private IProtector _protector;

        public ProtectorAI(ComponentsModel components, IPathfinderAI pathfinderAI, IProtector protector, Seeker seeker) : base(components, pathfinderAI)
        {
            _protector = protector;
            _seeker = seeker;
            PathfinderAI.OnReachedEndOfPath += ReachedTarget;
        }

        private void ReachedTarget() 
        {
            _protector.OnTargetReached();
            RecalculatePath();
        }

        public override Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            return PathfinderAI.CalculatePath(fromPosition);
        }

        public override void RecalculatePath()
        {
            currentTarget = _protector.CurrentTarget;

            if (_seeker.IsDone())
            {
                _seeker.StartPath(Components.RgdBody.position, currentTarget.position, PathfinderAI.OnPathComplete);
            }
        }
    }
}
