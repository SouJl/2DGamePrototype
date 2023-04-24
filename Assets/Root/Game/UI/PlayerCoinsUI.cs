using Root.PixelGame.Game.Items;
using TMPro;
using UnityEngine;

namespace Root.PixelGame.Game.UI
{
    internal class PlayerCoinsUI : MonoBehaviour, IGameElementUI<ICoins>
    {
        [SerializeField] private TMP_Text _coinsValueText;

        private ICoins _model;

        public void InitUI(ICoins model)
        {
            _model = model;
            _model.OnValueChanged += CoinsValueChanged;
            CoinsValueChanged();
        }
        public void DeinitUI()
        {
            _model.OnValueChanged -= CoinsValueChanged;
        }

        private void CoinsValueChanged()
        {
            _coinsValueText.text = _model.CurrentValue.ToString();
        }
    }
}
