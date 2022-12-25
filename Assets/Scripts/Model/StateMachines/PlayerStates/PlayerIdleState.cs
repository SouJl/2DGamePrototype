using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerIdleState : State
    {
        private float _xAxisInput;

        private bool _doJump;

        private bool _isJump;
        private bool _isRun;


        public PlayerIdleState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController)
        {

        }

        public override void Enter()
        {
            base.Enter();
            _isJump = false;
            _isRun = false;
            animatorController.StartAnimation(unit.SpriteRenderer, AnimaState.Idle, true);
        }

        public override void InputData()
        {
            base.InputData();
            _xAxisInput = Input.GetAxis("Horizontal");
            _isRun = Mathf.Abs(_xAxisInput) > unit.MoveModel.MovingThresh;
            _doJump = Input.GetKey(KeyCode.Space);
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(_isRun) stateMachine.ChangeState(unit.RunState);
            if(_isJump) stateMachine.ChangeState(unit.JumpState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            unit.SpriteRenderer.flipX = _xAxisInput < 0;

            if (unit.ContactsPoller.IsGrounded && _doJump && Mathf.Abs(unit.JumpModel.GetVelocity().y) <= 0.2f)
            {
                unit.JumpModel.Jump();
            }

            if (!unit.ContactsPoller.IsGrounded && _doJump)
            {
                _isJump = true;
            }
        }

        public override void Exit()
        {
            base.Exit();
            _isJump = false;
            _doJump = false;
            _isRun = false;
            animatorController.StopAnimation(unit.SpriteRenderer);
        }

    }
}
