using System;

namespace Root.PixelGame.Game.Core.Health
{
    internal interface IHealth
    {
        event Action OnHpChanged;

        float MaxValue { get; }
        float CurrentHealth { get; }

        void IncreaseHealth(float amount);
        void DecreaseHealth(float amount);

        void RestoreDefault();
    }
}
