﻿using PixelGame.Game.Core;
using UnityEngine;

namespace PixelGame.Game
{
    internal abstract class UnitView : MonoBehaviour, IDamageable, IKnockbackable
    {

        public abstract void Damage(float amount);

        public abstract void Knockback(Vector2 angle, float strength, int direction);
    }
}
