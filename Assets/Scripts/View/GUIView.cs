using UnityEngine;
using TMPro;
using PixelGame.Coins;

namespace PixelGame.View
{
    public class GUIView:MonoBehaviour
    {
        [SerializeField] private HealhBarView _healhBar;
        [SerializeField] private CoinsUI _coinsBar;

        public HealhBarView HealhBar => _healhBar;
        public CoinsUI CoinsBar => _coinsBar;
    }
}
