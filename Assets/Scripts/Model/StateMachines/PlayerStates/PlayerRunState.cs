using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerRunState : State
    {
        private Vector2 _horizontalInput;

        private bool _doJump;
        private bool _isJump;

        private bool _isStay;


        public PlayerRunState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController) 
        {

        }

        public override void Enter()
        {
            base.Enter();
            _isJump = false;
            _isStay = false;            
            animatorController.StartAnimation(unit.SpriteRenderer, AnimaState.Run, true);
        }

        public override void InputData()
        {
            base.InputData();

            _horizontalInput.x = Input.GetAxis("Horizontal");

            _doJump = Input.GetKey(KeyCode.Space);

            _isStay = _horizontalInput.magnitude == 0 && !_doJump ? true : false;  
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isJump) stateMachine.ChangeState(unit.JumpState);
            if (_isStay) stateMachine.ChangeState(unit.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            unit.SpriteRenderer.flipX = _horizontalInput.x < 0;

            unit.MoveModel.Move(_horizontalInput);


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
            animatorController.StopAnimation(unit.SpriteRenderer);
        }

    }
}
