using PixelGame.Game.Core.Health;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    internal interface IEnemyModel
    {
        IHealth Health { get; }

        public int CostForDefeat { get; }

        float Speed { get; }

        Transform SelfTransform { get; }
    }

    internal abstract class BaseEnemyModel : IEnemyModel
    {
        private readonly Transform _selfTransform;
        private readonly float _defaultSpeed;
        private readonly int _costForDefeat;
        public IHealth Health { get; protected set; }

        public int CostForDefeat => _costForDefeat;
        public float Speed { get; protected set; }

        public Transform SelfTransform => _selfTransform;   

        public BaseEnemyModel(
            Transform transform, 
            IEnemyData data)
        {
            _selfTransform = transform;

            Health = new HealthModel(data.MaxHealth);

            _defaultSpeed = data.Speed;
            _costForDefeat = data.CostForDefeat;

            SetDefaultValues();
          
        }

        public void SetDefaultValues()
        {
            Speed = _defaultSpeed;
        }
    }
}
