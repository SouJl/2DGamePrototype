using PixelGame.Components;
using PixelGame.Components.Core;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    [RequireComponent(typeof(ChaserAICoreComponent))]
    [RequireComponent(typeof(PatrolAICoreComponent))]
    internal class ProtectorEnemyView : EnemyView
    {
        [SerializeField] private ChaserAICoreComponent _chaseAICore;
        [SerializeField] private PatrolAICoreComponent _patrolAICore;
        [SerializeField] private LevelObjecTriggerComponent _protectionZone;

        public IEnemyCoreComponent ChaseAICore => _chaseAICore;
        public IEnemyCoreComponent PatrolAICore => _patrolAICore;

        public ILevelObjectTrigger ProtectionZone => _protectionZone;

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
