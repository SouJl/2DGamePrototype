using Root.PixelGame.Components.Core;
using Root.PixelGame.Game.Weapon;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    [RequireComponent(typeof(SimpleCoreComponent))]
    internal class StrandingEnemyView : EnemyView
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
