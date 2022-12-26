using PixelGame.Controllers;
using PixelGame.Enumerators;
using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerJumpState : PlayerState
    {
        private IJump _jumpModel;
        private bool _doJump;
        private bool _isGround;

        public PlayerJumpState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit) : base(stateMachine, animatorController, unit)
        {
            _jumpModel = player.JumpModel;
        }

        public override void Enter()
        {
            base.Enter();
            _doJump = true;
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isGround) stateMachine.ChangeState(player.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            player.SpriteRenderer.flipX = _xAxisInput < 0;

            _moveModel.Move(_xAxisInput);

            if (player.ContactsPoller.IsGrounded && _doJump && Mathf.Abs(_jumpModel.GetVelocity().y) <= _jumpModel.JumpThershold)
            {
                _jumpModel.Jump();
            }

            if (player.ContactsPoller.IsGrounded)
            {
                _isGround = true;
            }
            else if (Mathf.Abs(_jumpModel.GetVelocity().y) > 1f) 
            {
                animatorController.StartAnimation(player.SpriteRenderer, AnimaState.Jump, true);
                _doJump = false;
            }
        }

        public override void Exit()
        {
            base.Exit();
            _isGround = false;
            animatorController.StopAnimation(player.SpriteRenderer);
        }
    }
}
