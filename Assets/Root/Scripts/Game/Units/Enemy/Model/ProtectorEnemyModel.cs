using UnityEngine;

namespace PixelGame.Game.Enemy
{
    internal class ProtectorEnemyModel : BaseEnemyModel
    {
        public ProtectorEnemyModel(
            Transform transform,
            IEnemyData data) : base(transform, data)
        {
        }
    }
}
