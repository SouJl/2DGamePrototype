using Root.PixelGame.Game.Weapon;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class StandEnemyView : EnemyView
    {
        [SerializeField] private EnemyDataConfig _data;
        [SerializeField] private EnemyWeaponView _weapon;

        public IEnemyData Data => _data;
        public IWeaponView Weapon => _weapon;

        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }
    }
}
