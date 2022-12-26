using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerRunState : PlayerState
    {
        private bool _isStay;
        private bool _isJump;
        private bool _isRoll;

        public PlayerRunState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController) 
        {
        }

        public override void Enter()
        {
            base.Enter();
            animatorController.StartAnimation(player.SpriteRenderer, AnimaState.Run, true);
        }

        public override void InputData()
        {
            base.InputData();

            _isJump = _yAxisInput > 0;
            _isStay = _xAxisInput == 0 && !_isJump ? true : false;

            _isRoll = Input.GetKey(KeyCode.Space);
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isJump) stateMachine.ChangeState(player.JumpState);
            if (_isStay) stateMachine.ChangeState(player.IdleState);
            if (_isRoll) stateMachine.ChangeState(player.RollState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            player.SpriteRenderer.flipX = _xAxisInput < 0;

            _moveModel.Move(_xAxisInput);
        }


        public override void Exit()
        {
            base.Exit();
            _isJump = false;
            _isStay = false;
            _isRoll = false;
            animatorController.StopAnimation(player.SpriteRenderer);
        }

    }
}
