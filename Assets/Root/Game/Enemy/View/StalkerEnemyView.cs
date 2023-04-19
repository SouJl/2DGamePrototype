using Root.PixelGame.Components.Core;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    [RequireComponent(typeof(ChaserAICoreComponent))]
    internal class StalkerEnemyView : EnemyView
    {
        [SerializeField] private ChaserAICoreComponent _coreComponent;
        [SerializeField] private Transform _stalkerTarget;

        public IEnemyCoreComponent CoreComponent => _coreComponent;
        public Transform StalkerTarget => _stalkerTarget;

        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }
        private void OnValidate()
        {
            _coreComponent = GetComponent<ChaserAICoreComponent>();
        }
    }
}
