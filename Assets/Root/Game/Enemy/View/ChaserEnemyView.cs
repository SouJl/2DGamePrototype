using Root.PixelGame.Game.AI.ViewComponent;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class ChaserEnemyView : EnemyView
    {
        [SerializeField] private float _chaseBreakDistance = 10f;
        [SerializeField] private SeekerAIViewComponent _aIViewComponent;
        [SerializeField] private LevelObjecTriggerComponent _targetLocator;

        public float ChaseBreakDistance => _chaseBreakDistance;
        public IAIViewComponent AIViewComponent => _aIViewComponent;
        public ILevelObjectTrigger TargetLocator => _targetLocator;

        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }
    }
}
