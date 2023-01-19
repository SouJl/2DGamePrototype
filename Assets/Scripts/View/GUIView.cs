using UnityEngine;
using TMPro;

namespace PixelGame.View
{
    public class GUIView:MonoBehaviour
    {
        [SerializeField] private HealhBarView _healhBar;

        public HealhBarView HealhBar { get => _healhBar; }
    }
}
