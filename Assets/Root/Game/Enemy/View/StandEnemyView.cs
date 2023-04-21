using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class StandEnemyView : EnemyView
    {
        [SerializeField] private EnemyDataConfig _data;

        public IEnemyData Data => _data;

        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }
    }
}
