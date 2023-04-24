using System;

namespace Root.PixelGame.Game.Core.Health
{

    internal class HealthModel : IHealth
    {
        private readonly float _defaultHealth;
        private float _currentHealth;

        public HealthModel(float maxHealth)
        {
            _defaultHealth = maxHealth;
            _currentHealth = _defaultHealth;
        }

        public event Action OnHpChanged;

        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = Math.Clamp(value, 0, _defaultHealth);
            }
        }

        public float MaxValue => _defaultHealth;

        public void IncreaseHealth(float amount) 
            => ChangeHealth(_currentHealth + amount);
        public void DecreaseHealth(float amount) 
            => ChangeHealth(_currentHealth - amount);
        public void RestoreDefault()
            => ChangeHealth(_defaultHealth);

        private void ChangeHealth(float newHealth)
        {
            _currentHealth = newHealth;
            OnHpChanged?.Invoke();
        }
    }
}
