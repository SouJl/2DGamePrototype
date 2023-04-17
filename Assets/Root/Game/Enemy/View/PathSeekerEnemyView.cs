using Root.PixelGame.Components.Core;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    [RequireComponent(typeof(PatrolAICoreComponent))]
    internal class PathSeekerEnemyView : EnemyView
    {
        [SerializeField] private PatrolAICoreComponent _enemyCoreView;

        public override IEnemyCoreComponent EnemyCoreView => _enemyCoreView;

        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }
        private void OnValidate()
        {
            _enemyCoreView = GetComponent<PatrolAICoreComponent>();
        }
    }
}
