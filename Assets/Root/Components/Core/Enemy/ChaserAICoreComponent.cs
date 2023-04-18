using Root.PixelGame.Components.AI;
using UnityEngine;

namespace Root.PixelGame.Components.Core
{
    [RequireComponent(typeof(ChaseAIComponent))]
    internal class ChaserAICoreComponent : EnemyCoreComponent
    {
        [SerializeField] private ChaseAIComponent _aIViewComponent;
        public override IAIComponent AIViewComponent => _aIViewComponent;

        protected override void Awake()
        {
            base.Awake();
            _aIViewComponent ??= gameObject.GetComponent<ChaseAIComponent>();
        }

        private void OnValidate()
        {
            _aIViewComponent = gameObject.GetComponent<ChaseAIComponent>();
        }
    }
}
