using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class StandEnemyModel : BaseEnemyModel
    {
        public StandEnemyModel(
            Transform selfTransform, 
            IEnemyData data) : base(selfTransform, data)
        {
        }
    }
}
