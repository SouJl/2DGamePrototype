using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Components.AI
{
    [RequireComponent(typeof(Seeker))]
    internal class PatrolAIComponent : AIComponent
    {
        [Header("AIComponent Patrol Settings")]
        [SerializeField] private Seeker _seeker;
        [SerializeField] private Transform[] _patrolWayPoints;    

        public Seeker Seeker => _seeker;
        public IList<Transform> PatrolWayPoints => _patrolWayPoints;

        private void OnValidate()
        {
            _seeker ??= gameObject.GetComponent<Seeker>();
        }
    }
}
