using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerFallState : PlayerState
    {
        private bool _isGround;
        private bool _isWallSlide;

        public PlayerFallState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit) : base(stateMachine, animatorController, unit)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _isGround = false;
            animatorController.StartAnimation(_player.SpriteRenderer, AnimaState.Fall, true);
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
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            if (Mathf.Abs(_xAxisInput) > 0.1f)
            {
                _player.SpriteRenderer.flipX = _xAxisInput < 0;
                _moveModel.Move(_xAxisInput);
            }

            _isGround = _player.ContactsPoller.IsGrounded;

            if (!_jumpModel.IsWallJump && !_player.ContactsPoller.IsGrounded && (_player.ContactsPoller.HasLeftContacts || _player.ContactsPoller.HasRightContacts))
            {
                _isWallSlide = true;
            }

        }

        public override void Exit()
        {
            base.Exit();
            _isGround = false;
            _isWallSlide = false;
            animatorController.StopAnimation(_player.SpriteRenderer);
        }
    }
}
