using Pathfinding;
using UnityEngine;

namespace Root.PixelGame.Components.AI
{
    [RequireComponent(typeof(Seeker))]
    internal class SeekerAIViewComponent :MonoBehaviour,  IAIViewComponent
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Seeker _seeker;

        public Seeker Seeker => _seeker;
        public Transform Handler => gameObject.transform;
        public Transform Target => _target;

        private void OnValidate()
        {
            _seeker ??= gameObject.GetComponent<Seeker>();
        }
    }
}
