using Pathfinding;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.AI.Model
{
    internal interface IAIModel
    {
        void UpdatePath(Path p);
        Vector2 CalculateVelocity(Vector2 fromPosition);
    }

    internal abstract class BaseAIModel : IAIModel
    {
        protected Path path;

        public abstract Vector2 CalculateVelocity(Vector2 fromPosition);

        public abstract void UpdatePath(Path p);
    }
}
