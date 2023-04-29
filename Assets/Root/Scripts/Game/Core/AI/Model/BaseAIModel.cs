using Pathfinding;
using PixelGame.Components.AI;
using System;
using UnityEngine;

namespace PixelGame.Game.AI.Model
{
    internal interface IAIModel
    {
        void InitModel();
        void DeinitModel();

        Vector2 CalculateVelocity(Vector2 fromPosition);
    }

    internal abstract class BaseAIModel : IAIModel
    {
        protected IAIData data;
        protected Path path;

        public BaseAIModel(IAIData data)
        {
            this.data 
                = data ?? throw new ArgumentNullException(nameof(data));
        }

        public abstract Vector2 CalculateVelocity(Vector2 fromPosition);

        public virtual void DeinitModel() { }

        public virtual void InitModel() { }
    }
}
