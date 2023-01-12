using PixelGame.Controllers;
using PixelGame.Enumerators;
using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerJumpState : PlayerState
    {
        private bool _doJump;
        private bool _isGround;

        private bool _isWallSlide;
        private bool _isFall;

        public PlayerJumpState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit) : base(stateMachine, animatorController, unit)
        { 
        }

        public override void Enter()
        {
            base.Enter();
            _doJump = true;
            _isWallSlide = false;
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isGround) stateMachine.ChangeState(_player.IdleState);
            if (_isWallSlide) stateMachine.ChangeState(_player.WallSlideState);
            if (_isFall) stateMachine.ChangeState(_player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (_doJump && Mathf.Abs(_player.RgBody.velocity.y - _player.ContactsPoller.GroundVelocity.y) <= _jumpModel.JumpThershold)
            {
                _jumpModel.Jump();
            }
            
            if (_player.ContactsPoller.IsGrounded)
            {
                _isGround = true;
            }
            else if (Mathf.Abs(_player.RgBody.velocity.y) > _jumpModel.FlyThershold) 
            {
                animatorController.StartAnimation(_player.SpriteRenderer, AnimaState.Jump, true);
                _doJump = false;
            }

            if (!_jumpModel.IsWallJump && !_player.ContactsPoller.IsGrounded && (_player.ContactsPoller.HasLeftContacts || _player.ContactsPoller.HasRightContacts))
            {
                _isWallSlide = true;
            }

            if (!_player.ContactsPoller.IsGrounded && _player.RgBody.velocity.y < -_jumpModel.FlyThershold)
            {
                _isFall = true;
            }

        }

        public override void Exit()
        {
            base.Exit();
            _isGround = false;
            _isWallSlide = false;
            _isFall = false;
            animatorController.StopAnimation(_player.SpriteRenderer);
        }
    }
}
