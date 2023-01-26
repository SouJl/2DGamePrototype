using Pathfinding;
using UnityEngine;

namespace PixelGame.View
{
    public class WizzardEnemyView:EnemyView
    {
        [SerializeField] Seeker _seeker;
        [SerializeField] LevelObjectTrigger _protectedZone;

        public LevelObjectTrigger ProtectedZone { get => _protectedZone;}
        public Seeker Seeker { get => _seeker; }

        public override void Awake()
        {
            base.Awake();
            _seeker = GetComponent<Seeker>();
        }
    }
}
