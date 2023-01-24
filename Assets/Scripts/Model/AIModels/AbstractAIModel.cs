using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model.AIModels
{
    public abstract class AbstractAIModel
    {
        protected IPathfinderAI pathfinderAI { get; private set; }

        public AbstractAIModel(IPathfinderAI pathfinderAI) 
        {
            this.pathfinderAI = pathfinderAI;
        }

        public abstract void RecalculatePath(Vector2 target);
    }
}
