using PixelGame.Components.Core;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    [RequireComponent(typeof(ChaserAICoreComponent))]
    internal class PursuerEnemyView : EnemyView
    {
        [SerializeField] private ChaserAICoreComponent _coreComponent;

        public IEnemyCoreComponent CoreComponent => _coreComponent;
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
