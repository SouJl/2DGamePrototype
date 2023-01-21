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

            _rgdBody.velocity = Vector2.zero;
            _rgdBody.angularVelocity = 0;

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

            _rgdBody.sharedMaterial = _noneFriction;


            _wallDirection = WallDirection.None;

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
            else if (_rgdBody.velocity.y < -_jumpModel.FallThershold)
            {
                _isFall = true;
            }

            if (_wallDirection != WallDirection.None && !_isGround && _xAxisInput != 0)
            {
                _rgdBody.velocity = new Vector2(_rgdBody.velocity.x, Mathf.Clamp(_rgdBody.velocity.y, -_wallSlidingSpeed, float.MaxValue));
            }

            _isGround = _player.ContactsPoller.IsGrounded;


            _moveModel.Move(_xAxisInput);
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
                    _player.SpriteRenderer.flipX = true;
                    _player.JumpModel.Direction = new Vector2(-1, 1);
                    break;
                case WallDirection.Left:
                    _player.SpriteRenderer.flipX = false;
                    _player.JumpModel.Direction = new Vector2(1, 1);
                    break;
            }

            _jumpModel.IsWallJump = true;

            animatorController.StopAnimation(_player.SpriteRenderer);
        }

    }
}
