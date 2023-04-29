using PixelGame.Components.Core;
using PixelGame.Game.Weapon;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    [RequireComponent(typeof(SimpleCoreComponent))]
    internal class WanderEnemyView : EnemyView
    {
        [SerializeField] private SimpleCoreComponent _core;
        [SerializeField] private WeaponView _weapon;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Transform _wallCheck;

        public IEnemyCoreComponent Core => _core;
        public IWeaponView Weapon => _weapon;

        public Transform GroundCheck => _groundCheck;

        public Transform WallCheck => _wallCheck;

        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }
    }
}
