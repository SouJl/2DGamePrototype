using System.Collections.Generic;
using UnityEngine;

namespace Root.PixelGame.Components.AI
{
    internal class PatrolViewComponent: MonoBehaviour, IAIViewComponent
    {
        [SerializeField] private Transform[] _patrolWayPoints;

        public IList<Transform> PatrolWayPoints => _patrolWayPoints;
    }
}
