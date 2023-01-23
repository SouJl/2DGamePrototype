using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerIdleState : PlayerGroundState
    {
        private bool _isRun;
        private bool _isFall;

        public PlayerIdleState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState) : base(stateMachine, animatorController, unit, playerData, animaState)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocityX(0f);
        }

        public override void Exit()
        {
            base.Exit();
            _isRun = false;
            _isFall = false;
        }

        public override void InputData()
        {
            base.InputData();
            _isRun = Mathf.Abs(_xAxisInput) > playerData.moveThresh;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(_isRun) stateMachine.ChangeState(player.RunState);
            if(_isFall) stateMachine.ChangeState(player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            rgdBody.sharedMaterial = _fullFriction;        
        }


        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
