using PixelGame.Interfaces;
using System;
using UnityEngine;

namespace PixelGame.Model
{
    public class HealthModel : IHealth
    {
        private float _maxHealth;
        public float MaxHealth { get => _maxHealth; }
        
        private float _currentHealth;
        public float CurrentHealth 
        { 
            get => _currentHealth; 
            set 
            {
                _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
                OnHpChanged?.Invoke(_currentHealth);
            }
        }

        public Action<float> OnHpChanged { get; set; }

        public HealthModel(float healthPoints) 
        {
            _maxHealth = healthPoints;
        }
    }
}
