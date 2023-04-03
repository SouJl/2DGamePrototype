using Pathfinding;
using UnityEngine;

namespace Root.PixelGame.Game.AI.ViewComponent
{
    internal class SeekerAIViewComponent :MonoBehaviour,  IAIViewComponent
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Seeker _seeker;

        public Seeker Seeker => _seeker;
        public Transform Handler => gameObject.transform;
        public Transform Target => _target;
    }
}
