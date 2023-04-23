using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyModel
    {
        float Health { get; }
        float Speed { get; }

        Transform SelfTransform { get; }

        void TakeDamage(float amount);
    }

    internal abstract class BaseEnemyModel : IEnemyModel
    {
        protected readonly IEnemyView _view;
        private readonly float _defaultHealth;
        private readonly float _defaultSpeed;

        public float Health { get; protected set; }
        public float Speed { get; protected set; }

        public Transform SelfTransform => _view.EnemyTransform;

        public BaseEnemyModel(
            IEnemyView view, 
            IEnemyData data)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));
            
            _defaultHealth = data.MaxHealth;
            _defaultSpeed = data.Speed;

            SetDefaultValues();
          
        }

        public void SetDefaultValues()
        {
            Health = _defaultHealth;
            Speed = _defaultSpeed;
        }

        public abstract void TakeDamage(float amount);
    }
}
