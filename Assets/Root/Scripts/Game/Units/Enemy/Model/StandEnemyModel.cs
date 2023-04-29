using UnityEngine;

namespace PixelGame.Game.Enemy
{
    internal class StandEnemyModel : BaseEnemyModel
    {
        public StandEnemyModel(
            Transform transform, 
            IEnemyData data) : base(transform, data)
        {
        }
    }
}
