using Pathfinding;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.AI.Model
{
    internal interface IAIModel
    {
        void InitModel();
        void DeinitModel();

        Vector2 CalculateVelocity(Vector2 fromPosition);
    }

    internal abstract class BaseAIModel : IAIModel
    {
        protected IAIConfig config;
        protected Path path;

        public BaseAIModel(IAIConfig config)
        {
            this.config 
                = config ?? throw new ArgumentNullException(nameof(config));
        }

        public abstract Vector2 CalculateVelocity(Vector2 fromPosition);

        public virtual void DeinitModel() { }

        public virtual void InitModel() { }
    }
}
