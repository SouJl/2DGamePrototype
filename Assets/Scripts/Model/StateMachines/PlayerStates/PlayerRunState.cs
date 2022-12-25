using PixelGame.Controllers;
using PixelGame.Enumerators;
using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerRunState : State
    {
        private IMove _moveModel;
        private float _xAxisInput;
        private bool _isStay;

        private IJump _jumpModel;
        private bool _doJump;
        private bool _isJump;

        public PlayerRunState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController) 
        {
            _moveModel = unit.MoveModel;
            _jumpModel = unit.JumpModel;
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

            _xAxisInput = Input.GetAxis("Horizontal");

            _doJump = Input.GetKey(KeyCode.Space);

            _isStay = _xAxisInput == 0 && !_doJump ? true : false;  
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
            
            unit.SpriteRenderer.flipX = _xAxisInput < 0;

            _moveModel.Move(new Vector2(_xAxisInput, 0));


            if (unit.ContactsPoller.IsGrounded && _doJump && Mathf.Abs(_jumpModel.GetVelocity().y) <= _jumpModel.JumpThershold)
            {
                _jumpModel.Jump();
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
