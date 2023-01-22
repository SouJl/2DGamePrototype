using PixelGame.Enumerators;
using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractJumpModel: IJump
    {
        private IUnit _unit;
        private float _jumpForse;
        private float _jumpThershold;
        private float _flyThershold;
        private Vector2 _direction;


        public IUnit Unit { get => _unit; }
        public float JumpForse { get => _jumpForse; set => _jumpForse = value; }
        public float JumpThershold { get => _jumpThershold; set => _jumpThershold = value; }
        public float FlyThershold { get => _flyThershold; set => _flyThershold = value; }
        public Vector2 Direction { get => _direction; set => _direction = value; }

        protected Vector2 workVelocity;

        public AbstractJumpModel(IUnit unit, float jumpForce, float jumpThershold, float flyThershold) 
        {
            _unit = unit;
            _jumpForse = jumpForce;
            _jumpThershold = jumpThershold;
            _flyThershold = flyThershold;
        }

        public abstract void Jump(float velocity);
    }
}
