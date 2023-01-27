using Pathfinding;
using UnityEngine;

namespace PixelGame.View
{
    public class ProtectorEnemyView:EnemyView
    {
        [Header("Protector Settings")]
        [SerializeField] private float _speedMuliplier = 2f;
        [SerializeField] private Seeker _seeker;
        [SerializeField] private LevelObjectTrigger _protectedZone;

        public LevelObjectTrigger ProtectedZone { get => _protectedZone;}
        public Seeker Seeker { get => _seeker; }
        public float SpeedMuliplier { get => _speedMuliplier; }

        public override void Awake()
        {
            base.Awake();
            _seeker = GetComponent<Seeker>();
        }
    }
}
