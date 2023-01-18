using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerIdleState : PlayerState
    {
        private bool _isRun;
        private bool _isJump;
        private bool _isFall;

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

            _isJump = Input.GetKey(KeyCode.Space);
            _isRun = Mathf.Abs(_xAxisInput) > _moveModel.MovingThresh;
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(_isRun) stateMachine.ChangeState(_player.RunState);
            if(_isJump) stateMachine.ChangeState(_player.JumpState);
            if(_isFall) stateMachine.ChangeState(_player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (!_player.ContactsPoller.IsGrounded && !_player.Slope.IsOnSlope && _rgdBody.velocity.y < -_jumpModel.FlyThershold)
            {
                _isFall = true;
            }
        }

        public override void Exit()
        {
            base.Exit();
            _isJump = false;
            _isRun = false;
            _isFall = false;
            _player.JumpModel.Direction = Vector2.up;
            animatorController.StopAnimation(_player.SpriteRenderer);
        }

    }
}
