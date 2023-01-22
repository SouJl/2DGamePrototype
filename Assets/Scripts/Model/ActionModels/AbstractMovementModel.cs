using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractMovementModel : IMove
    {
        private IUnit _unit;
        private float _speed;
        private float _movingThresh;

        public IUnit Unit { get => _unit; }
        public float Speed { get => _speed; set => _speed = value; }
        public float MovingThresh { get => _movingThresh; set => _movingThresh = value; }

        protected Vector2 workVelocity;

        public AbstractMovementModel(IUnit unit, float walkSpeed, float movingThresh)
        {
            _unit = unit;
            _speed = walkSpeed;
            _movingThresh = movingThresh;
        }

        public abstract void Move(float velocity);
    }
}
