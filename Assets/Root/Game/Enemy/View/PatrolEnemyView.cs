using Root.PixelGame.Components.Core;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    [RequireComponent(typeof(PatrolCoreComponent))]
    internal  class PatrolEnemyView : EnemyView
    {
        [SerializeField] private PatrolCoreComponent _enemyCoreView;

        public override IEnemyCoreComponent EnemyCoreView => _enemyCoreView;

        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }

        private void OnValidate()
        {
            _enemyCoreView = GetComponent<PatrolCoreComponent>();
        }
    }
}
