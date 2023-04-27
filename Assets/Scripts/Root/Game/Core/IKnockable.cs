using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal interface IKnockbackable
    {
        void Knockback(Vector2 angle, float strength, int direction);
    }
}
