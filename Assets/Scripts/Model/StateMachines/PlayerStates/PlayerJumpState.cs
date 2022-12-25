using PixelGame.Controllers;
using PixelGame.Enumerators;
using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerJumpState : State 
    {
        private IMove _moveModel;
        private float _xAxisInput;

        private IJump _jumpModel;
        private bool _doJump;
        private bool _isGround;

        public PlayerJumpState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController)
        {
            _moveModel = unit.MoveModel;
            _jumpModel = unit.JumpModel;
        }

        public override void Enter()
        {
            base.Enter();
            _doJump = true;
            _isGround = false;
        }

        public override void InputData()
        {
            base.InputData();
            _xAxisInput = Input.GetAxis("Horizontal");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isGround) stateMachine.ChangeState(unit.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            unit.SpriteRenderer.flipX = _xAxisInput < 0;

            _moveModel.Move(_xAxisInput);

            if (unit.ContactsPoller.IsGrounded && _doJump && Mathf.Abs(_jumpModel.GetVelocity().y) <= _jumpModel.JumpThershold)
            {
                _jumpModel.Jump();
            }

            if (unit.ContactsPoller.IsGrounded)
            {
                _isGround = true;
            }
            else if (Mathf.Abs(_jumpModel.GetVelocity().y) > 1f) 
            {
                animatorController.StartAnimation(unit.SpriteRenderer, AnimaState.Jump, true);
                _doJump = false;
            }
        }

        public override void Exit()
        {
            base.Exit();
            _xAxisInput = 0f;
            _isGround = false;
            animatorController.StopAnimation(unit.SpriteRenderer);
        }
    }
}
