using Root.PixelGame.Game.Core.Health;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyModel
    {
        IHealth Health { get; }

        float Speed { get; }

        Transform SelfTransform { get; }
    }

    internal abstract class BaseEnemyModel : IEnemyModel
    {
        private readonly Transform _selfTransform;
        private readonly float _defaultSpeed;

        public IHealth Health { get; protected set; }

        public float Speed { get; protected set; }

        public Transform SelfTransform => _selfTransform;

        public BaseEnemyModel(
            Transform transform, 
            IEnemyData data)
        {
            _selfTransform = transform;

            Health = new HealthModel(data.MaxHealth);

            _defaultSpeed = data.Speed;

            SetDefaultValues();
          
        }

        public void SetDefaultValues()
        {
            Speed = _defaultSpeed;
        }
    }
}
