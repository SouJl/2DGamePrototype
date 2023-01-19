using System;

namespace PixelGame.Interfaces
{
    public interface IHealth
    {
        float MaxHealth { get; }

        float CurrentHealth { get; set; }

        Action<float> OnHpChanged { get; set; }
    }
}
