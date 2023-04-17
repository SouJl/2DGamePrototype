using Root.PixelGame.Components.Core;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    [RequireComponent(typeof(StalkerCoreComponent))]
    internal class ChaserEnemyView : EnemyView
    {
        [SerializeField] private StalkerCoreComponent _enemyCoreView;
        [SerializeField] private LevelObjecTriggerComponent _targetLocator;
        [SerializeField] private float _chaseBreakDistance = 10f;
       
        public float ChaseBreakDistance => _chaseBreakDistance;
        public override IEnemyCoreComponent EnemyCoreView => _enemyCoreView;
        public ILevelObjectTrigger TargetLocator => _targetLocator;

        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }
        private void OnValidate()
        {
            _enemyCoreView = GetComponent<StalkerCoreComponent>();
        }
    }
}
