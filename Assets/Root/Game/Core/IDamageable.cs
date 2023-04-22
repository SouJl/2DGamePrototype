using System;

namespace Root.PixelGame.Game.Core
{
    internal interface IDamageable
    {
        event Action OnHealthEnd;
        void Damage(float amount);
    }
}
