using System.Collections.Generic;
using UnityEngine;

namespace Root.PixelGame.Game.AI.ViewComponent
{
    internal class PatrolAIViewComponent: MonoBehaviour, IAIViewComponent
    {
        [SerializeField] private Transform[] _patrolWayPoints;

        public IList<Transform> PatrolWayPoints => _patrolWayPoints;
    }
}
