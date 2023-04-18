using Pathfinding;
using UnityEngine;

namespace Root.PixelGame.Components.AI
{
    [RequireComponent(typeof(Seeker))]
    internal class ChaseAIComponent : AIComponent
    {
        [Header("AIComponent Chaser Settings")]
        [SerializeField] private Seeker _seeker;
        [SerializeField] private Transform _target;

        public Seeker Seeker => _seeker;
        public Transform Target => _target;

        private void OnValidate()
        {
            _seeker ??= gameObject.GetComponent<Seeker>();
        }
    }
}
