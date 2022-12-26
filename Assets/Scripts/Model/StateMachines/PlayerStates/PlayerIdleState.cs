using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerIdleState : PlayerState
    {
        private bool _isRun;
        private bool _isJump;
      
        public PlayerIdleState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController)
        {
        }

        public override void Enter()
        {
            base.Enter();
            animatorController.StartAnimation(player.SpriteRenderer, AnimaState.Idle, true);
        }

        public override void InputData()
        {
            base.InputData();

            _isJump = _yAxisInput > 0;

            _isRun = Mathf.Abs(_xAxisInput) > _moveModel.MovingThresh;
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(_isRun) stateMachine.ChangeState(player.RunState);
            if(_isJump) stateMachine.ChangeState(player.JumpState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            _isJump = false;
            _isRun = false;
            animatorController.StopAnimation(player.SpriteRenderer);
        }

    }
}
