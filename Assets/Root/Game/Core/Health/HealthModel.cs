using System;

namespace Root.PixelGame.Game.Core.Health
{
    internal interface IHealth
    {
        float CurrentHealth { get; }

        void IncreaseHealth(float amount);
        void DecreaseHealth(float amount);

        void RestoreDefault();
    }

    internal class HealthModel : IHealth
    {
        private readonly float _defaultHealth;
        private float _currentHealth;

        public HealthModel(float maxHealth)
        {
            _defaultHealth = maxHealth;
            _currentHealth = _defaultHealth;
        }

        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = Math.Clamp(value, 0, _defaultHealth);
            }
        }

        public void IncreaseHealth(float amount) 
            => _currentHealth += amount;
        public void DecreaseHealth(float amount) 
            => _currentHealth -= amount;

        public void RestoreDefault() 
            => _currentHealth = _defaultHealth;
    }
}
