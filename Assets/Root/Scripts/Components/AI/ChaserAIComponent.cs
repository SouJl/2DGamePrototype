using Pathfinding;
using UnityEngine;

namespace PixelGame.Components.AI
{
    [RequireComponent(typeof(Seeker))]
    internal class ChaserAIComponent : AIComponent
    {
        [Header("AIComponent Chaser Settings")]
        [SerializeField] private Seeker _seeker;

        public Seeker Seeker => _seeker;

        private void OnValidate()
        {
            _seeker ??= gameObject.GetComponent<Seeker>();
        }
    }
}
