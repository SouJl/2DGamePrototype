using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerIdleState : PlayerState
    {
        private bool _isRun;
        private bool _isJump;

        public PlayerIdleState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit) : base(stateMachine, animatorController, unit)
        {
        }

        public override void Enter()
        {
            base.Enter();
            animatorController.StartAnimation(_player.SpriteRenderer, AnimaState.Idle, true);
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
            if(_isRun) stateMachine.ChangeState(_player.RunState);
            if(_isJump) stateMachine.ChangeState(_player.JumpState);
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
            _player.JumpModel.Direction = Vector2.up;
            animatorController.StopAnimation(_player.SpriteRenderer);
        }

    }
}
