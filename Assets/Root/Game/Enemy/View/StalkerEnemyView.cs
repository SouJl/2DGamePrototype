using Root.PixelGame.Components.Core;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    [RequireComponent(typeof(StalkerCoreComponent))]
    internal class StalkerEnemyView : EnemyView
    {
        [SerializeField] private StalkerCoreComponent _enemyCoreView;

        public override IEnemyCoreComponent EnemyCoreView => _enemyCoreView;

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
