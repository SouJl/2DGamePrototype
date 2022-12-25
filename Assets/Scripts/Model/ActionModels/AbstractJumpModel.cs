using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractJumpModel: IJump
    {
        private Rigidbody2D _rgdbody;
        private float _jumpForse;

        public float JumpForse { get => _jumpForse; set => _jumpForse = value; }
        public Rigidbody2D Rgdbody { get => _rgdbody; }

        public AbstractJumpModel(Rigidbody2D rigidbody, float jumpForce) 
        {
            _rgdbody = rigidbody;
            _jumpForse = jumpForce;
        }

        public abstract void Jump();

        public Vector2 GetVelocity() => Rgdbody.velocity;

        public float GetPosition() => Rgdbody.position.y;

    }
}
