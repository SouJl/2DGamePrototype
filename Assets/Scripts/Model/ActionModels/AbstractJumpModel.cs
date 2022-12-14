using PixelGame.Enumerators;
using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractJumpModel: IJump
    {
        private Rigidbody2D _rgdbody;
        private float _jumpForse;
        private float _jumpThershold;
        private float _flyThershold;
        private Vector2 _direction;

        public float JumpForse { get => _jumpForse; set => _jumpForse = value; }
        public Rigidbody2D Rgdbody { get => _rgdbody; }
        public float JumpThershold { get => _jumpThershold; set => _jumpThershold = value; }
        public float FlyThershold { get => _flyThershold; set => _flyThershold = value; }
        public Vector2 Direction { get => _direction; set => _direction = value; }

        public AbstractJumpModel(Rigidbody2D rigidbody, float jumpForce, float jumpThershold, float flyThershold) 
        {
            _rgdbody = rigidbody;
            _jumpForse = jumpForce;
            _jumpThershold = jumpThershold;
            _flyThershold = flyThershold;
        }

        public abstract void Jump();
    }
}
