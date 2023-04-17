using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

namespace Root.PixelGame.Components.AI
{
    [RequireComponent(typeof(Seeker))]
    internal class PatrolAIComponent : MonoBehaviour, IAIViewComponent
    {
        [SerializeField] private Seeker _seeker;
        [SerializeField] private Transform[] _patrolWayPoints;    

        public Seeker Seeker => _seeker;
        public Transform Handler => gameObject.transform;
        public IList<Transform> PatrolWayPoints => _patrolWayPoints;

        private void OnValidate()
        {
            _seeker ??= gameObject.GetComponent<Seeker>();
        }
    }
}
