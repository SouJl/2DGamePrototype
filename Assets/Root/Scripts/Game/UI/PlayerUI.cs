using PixelGame.Game.Core.Health;
using PixelGame.Game.Items;
using UnityEngine;

namespace PixelGame.Game.UI
{
    internal class PlayerUI : MonoBehaviour
    {
        [SerializeField] private PlayerHealthUI _healthUI;
        [SerializeField] private PlayerCoinsUI _coinsUI;


        public IGameElementUI<IHealth> HealthUI => _healthUI;
        public IGameElementUI<ICoins> CoinsUI => _coinsUI;

    }
}
