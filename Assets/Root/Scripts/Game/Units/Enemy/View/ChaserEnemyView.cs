using PixelGame.Components;
using PixelGame.Components.Core;
using PixelGame.Game.Weapon;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    [RequireComponent(typeof(PatrolAICoreComponent))]
    internal class ChaserEnemyView : EnemyView
    {
        [SerializeField] private WeaponView _weapon;
        [SerializeField] private PatrolAICoreComponent _chaseAICore;
        [SerializeField] private LevelObjecTriggerComponent _targetLocator;
        [SerializeField] private float _chaseBreakDistance = 10f;

        public IEnemyCoreComponent ChaseAICore => _chaseAICore;
        public IWeaponView Weapon => _weapon;

        public ILevelObjectTrigger TargetLocator => _targetLocator;
        
        public float ChaseBreakDistance => _chaseBreakDistance;

        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }

        private void OnValidate()
        {
            _chaseAICore = GetComponent<PatrolAICoreComponent>();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _chaseBreakDistance);
        }
    }
}
