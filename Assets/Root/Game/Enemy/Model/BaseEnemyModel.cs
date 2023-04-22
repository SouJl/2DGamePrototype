using Root.PixelGame.Game.Core;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyModel : IDamageable
    {
        float Health { get; }
        float Speed { get; }

        Transform SelfTransform { get; }
    }

    internal abstract class BaseEnemyModel : IEnemyModel
    {
        private readonly Transform _selfTransform;
        private readonly float _defaultHealth;
        private readonly float _defaultSpeed;

        public abstract event Action OnHealthEnd;

        public float Health { get; protected set; }
        public float Speed { get; protected set; }

        public Transform SelfTransform => _selfTransform;

        public BaseEnemyModel(
            Transform selfTransform, 
            IEnemyData data)
        {
            _selfTransform = selfTransform;
            _defaultHealth = data.MaxHealth;
            _defaultSpeed = data.Speed;

            SetDefaultValues();
          
        }

        public void SetDefaultValues()
        {
            Health = _defaultHealth;
            Speed = _defaultSpeed;
        }

        public abstract void Damage(float amount);
    }
}
