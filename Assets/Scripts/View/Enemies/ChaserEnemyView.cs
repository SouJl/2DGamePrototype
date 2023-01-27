using Pathfinding;
using UnityEngine;

namespace PixelGame.View
{
    public class ChaserEnemyView:EnemyView
    {
        [SerializeField] private float _chaseBreakDistance = 10f;
        [SerializeField] private LevelObjectTrigger _targetLocator;
        [SerializeField] Seeker _seeker;


        public Seeker Seeker { get => _seeker; }
        public float ChaseBreakDistance { get => _chaseBreakDistance;  }
        public LevelObjectTrigger TargetLocator { get => _targetLocator;  }

        public override void Awake()
        {
            base.Awake();
            _seeker = GetComponent<Seeker>();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _chaseBreakDistance);
        }
    }
}
