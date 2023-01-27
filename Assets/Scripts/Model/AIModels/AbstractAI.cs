using PixelGame.Configs;
using UnityEngine;

namespace PixelGame.Model.AIModels
{
    public abstract class AbstractAI
    {
        private AIConfig _config;
        public AIConfig Config { get => _config; }

        public AbstractAI(AIConfig config)
        {
            _config = config;
        }

        public abstract void Init();
        public abstract void Deint();

        public abstract void Update(float time);

        public abstract Vector2 CalculateVelocity(Vector2 fromPosition);
    }
}
