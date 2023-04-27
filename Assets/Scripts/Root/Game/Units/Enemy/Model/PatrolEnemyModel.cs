using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class PatrolEnemyModel : BaseEnemyModel
    {
        public PatrolEnemyModel(
            Transform transform,
            IEnemyData data) : base(transform, data)
        {
        }
    }
}
