using Pathfinding;
using PixelGame.Interfaces;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model.AIModels
{
    public class StalkerAI : AbstractAIModel
    {
        private Seeker _seeker;

        public StalkerAI(ComponentsModel components, IPathfinderAI pathfinderAI, Seeker seeker, Transform target) : base(components, pathfinderAI)
        {
            _seeker = seeker;
            currentTarget = target;
        }

        public override void RecalculatePath()
        {
            if (_seeker.IsDone())
            {
                _seeker.StartPath(Components.RgdBody.position, currentTarget.position, PathfinderAI.OnPathComplete);
            }

        }

        public override Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            return PathfinderAI.CalculatePath(fromPosition);
        }
    }
}
