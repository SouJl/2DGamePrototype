using Root.PixelGame.Components.Core;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    [RequireComponent(typeof(ChaserAICoreComponent))]
    [RequireComponent(typeof(PatrolAICoreComponent))]
    internal class ChaserEnemyView : EnemyView
    {
        [SerializeField] private ChaserAICoreComponent _chaseAICore;
        [SerializeField] private PatrolAICoreComponent _patrolAICore;
        [SerializeField] private LevelObjecTriggerComponent _targetLocator;
        [SerializeField] private float _chaseBreakDistance = 10f;

        public IEnemyCoreComponent ChaseAICore => _chaseAICore;
        public IEnemyCoreComponent PatrolAICore => _patrolAICore;

        public ILevelObjectTrigger TargetLocator => _targetLocator;
        public float ChaseBreakDistance => _chaseBreakDistance;

        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }

        private void OnValidate()
        {
            _chaseAICore = GetComponent<ChaserAICoreComponent>();
            _patrolAICore = GetComponent<PatrolAICoreComponent>();
        }
    }
}
