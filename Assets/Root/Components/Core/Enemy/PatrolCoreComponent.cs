using Root.PixelGame.Components.AI;
using UnityEngine;

namespace Root.PixelGame.Components.Core
{
    [RequireComponent(typeof(PatrolViewComponent))]
    internal class PatrolCoreComponent :EnemyCoreComponent
    {
        [SerializeField] private PatrolViewComponent _aIViewComponent;

        public override IAIViewComponent AIViewComponent => _aIViewComponent;

        protected override void Awake()
        {
            base.Awake();
            _aIViewComponent ??= gameObject.GetComponent<PatrolViewComponent>();
        }

        private void OnValidate()
        {
            _aIViewComponent = gameObject.GetComponent<PatrolViewComponent>();
        }
    }
}
