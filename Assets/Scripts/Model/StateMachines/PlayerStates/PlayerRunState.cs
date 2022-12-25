using PixelGame.Controllers;
using PixelGame.Enumerators;
using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerRunState : PlayerState
    {
        private IMove _moveModel;
        private float _xAxisInput;

        private bool _isStay;
        private bool _isJump;
        private bool _isRoll;

        public PlayerRunState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController) 
        {
            _moveModel = player.MoveModel;
        }

        public override void Enter()
        {
            base.Enter();
            _xAxisInput = 0f;
            animatorController.StartAnimation(player.SpriteRenderer, AnimaState.Run, true);
        }

        public override void InputData()
        {
            base.InputData();

            _isJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
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
