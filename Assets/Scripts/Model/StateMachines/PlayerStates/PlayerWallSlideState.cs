using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerWallSlideState : PlayerState
    {
        private enum WallDirection
        {
            None,
            Left,
            Right
        }

        private WallDirection _wallDirection = WallDirection.None;
        private float _wallSlidingSpeed;

        private bool _isJump;
        private bool _isGround;
        private bool _isFall;


        public PlayerWallSlideState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, float wallSlideSpeed) : base(stateMachine, animatorController, unit)
        {
            _wallSlidingSpeed = wallSlideSpeed;
        }

        public override void Enter()
        {
            base.Enter();
            
            _player.RgBody.velocity = Vector2.zero;
            _player.RgBody.angularVelocity = 0;

            _isJump = false;
            _isGround = false;
            animatorController.StartAnimation(_player.SpriteRenderer, AnimaState.WallSlide, true);
        }

        public override void InputData()
        {
            base.InputData();
            _isJump = Input.GetKey(KeyCode.Space);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isGround) stateMachine.ChangeState(_player.IdleState);
            if (_isJump) stateMachine.ChangeState(_player.JumpState);
            if (_isFall) stateMachine.ChangeState(_player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
         
            _moveModel.Move(_xAxisInput);

            if (_player.ContactsPoller.HasRightContacts)
            {
                _player.SpriteRenderer.flipX = true;
                _wallDirection = WallDirection.Right;
            }
            else if (_player.ContactsPoller.HasLeftContacts)
            {
                _player.SpriteRenderer.flipX = false;
                _wallDirection = WallDirection.Left;
            }
            else if (_player.RgBody.velocity.y < -_jumpModel.FlyThershold)
            {         
                _isFall = true;
            }

            _player.RgBody.velocity = new Vector2(_player.RgBody.velocity.x, Mathf.Clamp(_player.RgBody.velocity.y, -_wallSlidingSpeed, float.MaxValue));


            _isGround = _player.ContactsPoller.IsGrounded;
        }


        public override void Exit()
        {
            base.Exit();

            _isJump = false;
            _isGround = false;
            _isFall = false;

            switch (_wallDirection)
            {
                case WallDirection.Right:
                    _player.JumpModel.Direction = new Vector2(-1, 1);
                    break;
                case WallDirection.Left:
                    _player.JumpModel.Direction = new Vector2(1, 1);
                    break;
            }

            _jumpModel.IsWallJump = true;

            animatorController.StopAnimation(_player.SpriteRenderer);
        }

    }
}
