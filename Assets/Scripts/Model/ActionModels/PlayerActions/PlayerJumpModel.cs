using UnityEngine;

namespace PixelGame.Model
{
    public class PlayerJumpModel : AbstractJumpModel
    {

        private bool _isWallJump;
        private float _wallJumpTime;
  
        public PlayerJumpModel(Rigidbody2D rigidbody, float jumpForce, float jumpThershold, float flyThershold) : base(rigidbody, jumpForce, jumpThershold, flyThershold) 
        {
            Direction = Vector2.up;
            _wallJumpTime = 0.1f;
        }

        public override void Jump()
        {
            Rgdbody.AddForce(Direction * JumpForse);
        }

        public bool IsWallJump 
        {
            get 
            {
                if (_isWallJump) 
                {
                    if (_wallJumpTime > 0)
                    {
                        _wallJumpTime -= Time.fixedDeltaTime;
                    }
                    else 
                    {
                        _wallJumpTime = 0.1f;
                        _isWallJump = false;
                    }
                }
                return _isWallJump;
            }
            set 
            {
                if(_isWallJump != value) 
                {
                    _isWallJump = value;
                }
            }
        }
    }
}
