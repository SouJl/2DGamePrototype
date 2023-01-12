using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.View
{
    public class JointsCollectionView:MonoBehaviour
    {
        [SerializeField] private List<LiftView> _lifts;

        public List<LiftView> Lifts { get => _lifts; }
    }
}
