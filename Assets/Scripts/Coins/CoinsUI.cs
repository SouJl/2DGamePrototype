using UnityEngine;
using TMPro;

namespace PixelGame.Coins
{
    public interface ICoinsUI
    {
        void Init();
        void IncreaseCoinsValue(int amount);
        void DecreaseCoinsValue(int amount);
    }

    public class CoinsUI : MonoBehaviour, ICoinsUI
    {
        [SerializeField] private TMP_Text _coinsValueText;

        private int _coinsAmount;

        public void Init()
        {
            _coinsAmount = 0;
            _coinsValueText.text = GetStringCoinsValue(_coinsAmount);
        }

        public void IncreaseCoinsValue(int amount) =>
            _coinsValueText.text = GetStringCoinsValue(_coinsAmount += amount);

        public void DecreaseCoinsValue(int amount) =>
            _coinsValueText.text = GetStringCoinsValue(_coinsAmount -= amount);

        private string GetStringCoinsValue(int coinsAmountValue) =>
            $"Coins: {coinsAmountValue}";

    }
}
