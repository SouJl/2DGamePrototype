using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.View
{
    public class WizzardEnemyView:EnemyView
    {
        [SerializeField] List<Transform> _wayPoints; 
        [SerializeField] LevelObjectTrigger _protectedZone;

        public LevelObjectTrigger ProtectedZone { get => _protectedZone;}
        public List<Transform> WayPoints { get => _wayPoints;}
    }
}
