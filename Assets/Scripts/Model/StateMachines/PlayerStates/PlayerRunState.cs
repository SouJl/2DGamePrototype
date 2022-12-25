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
        private bool _isJump;

        public PlayerRunState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController) 
        {
            _moveModel = unit.MoveModel;
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

            _isJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            _isStay = _xAxisInput == 0 && !_isJump ? true : false;  
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

            _moveModel.Move(_xAxisInput);
        }


        public override void Exit()
        {
            base.Exit();
            _isJump = false;
            animatorController.StopAnimation(unit.SpriteRenderer);
        }

    }
}
