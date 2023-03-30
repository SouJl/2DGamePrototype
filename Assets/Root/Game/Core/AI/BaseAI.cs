using System;
using UnityEngine;

namespace Root.PixelGame.Game.AI
{
    internal interface IAIBehaviour
    {
        void Init();
        void Deinit();
        Vector2 GetNewVelocity(Vector2 fromPosition);
        void UpdateParameters(float time);
    }

    internal abstract class BaseAI : IAIBehaviour
    {
        protected readonly IAIConfig _config;
        public BaseAI(IAIConfig config)
        {
            _config 
                = config ?? throw new ArgumentNullException(nameof(config));
        }

        public abstract void Init();
        public abstract void Deinit();

        public abstract Vector2 GetNewVelocity(Vector2 fromPosition);

        public virtual void UpdateParameters(float time) { }
    }
}
