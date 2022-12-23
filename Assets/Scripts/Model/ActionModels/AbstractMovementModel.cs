using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractMovementModel : IMove
    {
        private Rigidbody2D _rgdbody;
        private float _speed;
        private float _movingThresh;

        public Rigidbody2D Rgdbody { get => _rgdbody; }
        public float Speed { get => _speed; set => _speed = value; }
        public float MovingThresh { get => _movingThresh; set => _movingThresh = value; }

        public AbstractMovementModel(Rigidbody2D rgdbody, float walkSpeed, float movingThresh)
        {
            _rgdbody = rgdbody;
            _speed = walkSpeed;
            _movingThresh = movingThresh;
        }

        public abstract void Move(Vector2 input);
    }
}
