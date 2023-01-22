using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerIdleState : PlayerGroundState
    {
        private bool _isRun;
        private bool _isFall;

        public PlayerIdleState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, AnimaState animaState) : base(stateMachine, animatorController, unit, animaState)
        {

        }

        public override void Enter()
        {
            base.Enter();
            _player.SetVelocityX(0f);
        }

        public override void Exit()
        {
            base.Exit();
            _isRun = false;
            _isFall = false;
            _player.JumpModel.Direction = Vector2.up;
        }

        public override void InputData()
        {
            base.InputData();
            _isRun = Mathf.Abs(_xAxisInput) > _moveModel.MovingThresh;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(_isRun) stateMachine.ChangeState(_player.RunState);
            if(_isFall) stateMachine.ChangeState(_player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _rgdBody.sharedMaterial = _fullFriction;        
        }


        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
