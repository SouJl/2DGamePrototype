﻿using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerIdleState : PlayerGroundState
    {
        private bool _isRun;
        private bool _isFall;

        public PlayerIdleState(
                 IStateHandler stateHandler,
                 IPlayerCore playerCore,
                 IPlayerData playerData,
                 IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }

        public override void Enter()
        {
            base.Enter();
            playerCore.PhysicModel.SetVelocityX(0f);
            animator.StartAnimation(AnimationType.Idle);
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
            _isRun = Mathf.Abs(_xAxisInput) > playerData.MoveThresh;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isRun) 
                ChangeState(StateType.RunState);
            if (_isFall) ChangeState(StateType.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            playerCore.PhysicModel.ChangePhysicsMaterial(_fullFriction);
        }


        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
