using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.View
{
    public class WizzardEnemyView:EnemyView
    {
        [SerializeField] Seeker _seeker;
        [SerializeField] List<Transform> _wayPoints; 
        [SerializeField] LevelObjectTrigger _protectedZone;

        public LevelObjectTrigger ProtectedZone { get => _protectedZone;}
        public List<Transform> WayPoints { get => _wayPoints;}
        public Seeker Seeker { get => _seeker; }

        public override void Awake()
        {
            base.Awake();
            _seeker = GetComponent<Seeker>();
        }
    }
}
