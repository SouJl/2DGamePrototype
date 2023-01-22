using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public class PlayerJumpModel : AbstractJumpModel
    {
        private float _fallThershold;
        private bool _isWallJump;
        private float _wallJumpTime;

        public float FallThershold { get => _fallThershold; }

        public PlayerJumpModel(IUnit unit, float jumpForce, float jumpThershold, float flyThershold, float fallThershold) : base(unit, jumpForce, jumpThershold, flyThershold) 
        {
            Direction = Vector2.up;
            _wallJumpTime = 0.1f;
            _fallThershold = fallThershold;
        }

        public override void Jump(float velocity)
        {
            workVelocity.Set(Unit.CurrentVelocity.x, velocity);
            Unit.UnitComponents.RgdBody.velocity = workVelocity;
            Unit.CurrentVelocity = workVelocity;
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
