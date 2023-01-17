using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerRunState : PlayerState
    {
        private bool _isStay;
        private bool _isJump;
        private bool _isRoll;

        private bool _isWallSlide;
        private bool _isFall;

        public PlayerRunState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit) : base(stateMachine, animatorController, unit)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _isWallSlide = false;
            animatorController.StartAnimation(_player.SpriteRenderer, AnimaState.Run, true);
        }

        public override void InputData()
        {
            base.InputData();

            _isJump = _yAxisInput > 0;
            _isStay = _xAxisInput == 0 && !_isJump ? true : false;
            _isRoll = Input.GetKey(KeyCode.Space);
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isJump)
            {
                _player.JumpModel.Direction = Vector2.up;
                stateMachine.ChangeState(_player.JumpState);
            }
            if (_isStay) stateMachine.ChangeState(_player.IdleState);
            if (_isRoll) stateMachine.ChangeState(_player.RollState);

            if (_isWallSlide) stateMachine.ChangeState(_player.WallSlideState);
            if (_isFall) stateMachine.ChangeState(_player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _player.SpriteRenderer.flipX = _xAxisInput < 0;

            if (!_player.Slope.IsOnSlope) 
            {
                _moveModel.Move(_xAxisInput);
            }
            else if (_player.Slope.IsOnSlope && _player.Slope.CanWalkOnSlope)
            {
                var newVel = new Vector2(_player.Slope.SlopeNormalPerp.x * -_xAxisInput, _player.Slope.SlopeNormalPerp.y * -_xAxisInput);
                _moveModel.Move(newVel);
            }
            
            if (!_jumpModel.IsWallJump && !_player.ContactsPoller.IsGrounded && (_player.ContactsPoller.HasLeftContacts || _player.ContactsPoller.HasRightContacts))
            {
                _isWallSlide = true;
            }

            if (!_player.ContactsPoller.IsGrounded && _rgdBody.velocity.y < -_jumpModel.FlyThershold)
            {
                _isFall = true;
            }
        }


        public override void Exit()
        {
            base.Exit();
            _isJump = false;
            _isStay = false;
            _isRoll = false;
            _isWallSlide = false;
            _isFall = false;
            animatorController.StopAnimation(_player.SpriteRenderer);
        }

    }
}
