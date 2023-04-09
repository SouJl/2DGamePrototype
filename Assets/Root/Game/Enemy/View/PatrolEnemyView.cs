using Root.PixelGame.Game.AI.ViewComponent;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    [RequireComponent(typeof(PatrolAIViewComponent))]
    internal  class PatrolEnemyView : EnemyView
    {
        [SerializeField] private PatrolAIViewComponent _aIViewComponent;

        public IAIViewComponent AIViewComponent => _aIViewComponent;


        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }

        private void OnValidate()
        {
            _aIViewComponent = GetComponent<PatrolAIViewComponent>();
        }
    }
}
