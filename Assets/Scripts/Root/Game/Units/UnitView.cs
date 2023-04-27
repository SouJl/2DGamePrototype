using Root.PixelGame.Game.Core;
using UnityEngine;

namespace Root.PixelGame.Game
{
    internal abstract class UnitView : MonoBehaviour, IDamageable
    {

        public abstract void Damage(float amount);
    }
}
