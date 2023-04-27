using Root.PixelGame.Components.AI;
using UnityEngine;

namespace Root.PixelGame.Components.Core
{
    [RequireComponent(typeof(PatrolAIComponent))]
    internal class PatrolAICoreComponent : EnemyCoreComponent
    {
        [SerializeField] private PatrolAIComponent _aIViewComponent;

        public override IAIComponent AIViewComponent => _aIViewComponent;

        protected override void Awake()
        {
            base.Awake();
            _aIViewComponent ??= gameObject.GetComponent<PatrolAIComponent>();
        }

        private void OnValidate()
        {
            _aIViewComponent = gameObject.GetComponent<PatrolAIComponent>();
        }
    }
}
