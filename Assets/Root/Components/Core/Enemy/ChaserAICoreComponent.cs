using Root.PixelGame.Components.AI;
using UnityEngine;

namespace Root.PixelGame.Components.Core
{
    [RequireComponent(typeof(ChaserAIComponent))]
    internal class ChaserAICoreComponent : EnemyCoreComponent
    {
        [SerializeField] private ChaserAIComponent _aIViewComponent;
        public override IAIComponent AIViewComponent => _aIViewComponent;

        protected override void Awake()
        {
            base.Awake();
            _aIViewComponent ??= gameObject.GetComponent<ChaserAIComponent>();
        }

        private void OnValidate()
        {
            _aIViewComponent = gameObject.GetComponent<ChaserAIComponent>();
        }
    }
}
