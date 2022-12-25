using PixelGame.Controllers;
using PixelGame.Enumerators;
using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerIdleState : State
    {
        private IMove _moveModel;
        private float _xAxisInput;

        private bool _isRun;
        private bool _isJump;
      
        public PlayerIdleState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController)
        {
            _moveModel = unit.MoveModel;
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

            _isJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            _isRun = Mathf.Abs(_xAxisInput) > _moveModel.MovingThresh;
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
       
        }

        public override void Exit()
        {
            base.Exit();
            _isJump = false;
            _isRun = false;
            animatorController.StopAnimation(unit.SpriteRenderer);
        }

    }
}
