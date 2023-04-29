using UnityEngine;

namespace PixelGame.Game.Enemy
{
    internal class PursuerEnemyModel : BaseEnemyModel
    {
        public PursuerEnemyModel(
            Transform transform,
            IEnemyData data) : base(transform, data)
        {
        }
    }
}
