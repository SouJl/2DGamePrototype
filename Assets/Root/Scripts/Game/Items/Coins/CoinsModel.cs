using System;

namespace PixelGame.Game.Items
{
    internal interface ICoins
    {
        event Action OnValueChanged;

        int MaxValue { get; }
        int CurrentValue { get; }

        void Increase(int amount);
        void Decrease(int amount);
    }

    internal class CoinsModel : ICoins
    {
        private readonly int _maxCoins = 1000;
        private int _currentCoins;

        public CoinsModel()
        {
            _currentCoins = 0;
        }

        public int MaxValue => _maxCoins;

        public int CurrentValue
        {
            get => _currentCoins;
            set
            {
                _currentCoins = Math.Clamp(value, 0, _maxCoins);
            }
        }

        public event Action OnValueChanged;


        public void Decrease(int amount) 
            => ChangeCoinsValue(_currentCoins - amount);

        public void Increase(int amount) 
            => ChangeCoinsValue(_currentCoins + amount);

        private void ChangeCoinsValue(int newValue)
        {
            _currentCoins = newValue;
            OnValueChanged?.Invoke();
        }
    }
}
