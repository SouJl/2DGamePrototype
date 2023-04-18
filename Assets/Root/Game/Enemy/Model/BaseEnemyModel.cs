using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyModel
    {
        Transform SelfTransform { get; }
    }

    internal abstract class BaseEnemyModel : IEnemyModel
    {
        private readonly Transform _selfTransform;
        private readonly float _defaultHealth;
        private readonly float _defaultSpeed;

        public float Health { get; set; }
        public float Speed { get; set; }

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
    }
}
