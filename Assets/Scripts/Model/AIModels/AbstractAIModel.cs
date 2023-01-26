using PixelGame.Interfaces;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model.AIModels
{
    public abstract class AbstractAIModel
    {
        protected Transform currentTarget;

        public ComponentsModel Components { get; private set; }
        public IPathfinderAI PathfinderAI { get; private set; }

        public AbstractAIModel(ComponentsModel components, IPathfinderAI pathfinderAI) 
        {
            Components = components;
            PathfinderAI = pathfinderAI;
        }

        public abstract void RecalculatePath();

        public abstract Vector2 CalculateVelocity(Vector2 fromPosition);
    }
}
