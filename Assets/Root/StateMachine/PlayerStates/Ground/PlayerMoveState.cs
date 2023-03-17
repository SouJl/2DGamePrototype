﻿using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerMoveState : PlayerGroundState
    {
        private bool _isStay;
        private bool _isWallSlide;
        private bool _isFall;

        public PlayerMoveState(
            IStateHandler stateHandler,
            IPlayerCore playerCore,
            IPlayerData playerData,
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _isWallSlide = false;
            animator.StartAnimation(AnimationType.Run);
        }

        public override void Exit()
        {
            base.Exit();
            _isStay = false;
            _isWallSlide = false;
            _isFall = false;
        }

        public override void InputData()
        {
            base.InputData();
            _isStay = _xAxisInput == 0 ? true : false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_isStay) ChangeState(StateType.IdleState);
            if (_isWallSlide) ChangeState(StateType.WallSlideState);
            if (_isFall) ChangeState(StateType.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            playerCore.CheckFlip(_xAxisInput);

            if (!playerCore.SlopeAnaliser.IsOnSlope)
            {
                playerCore.PhysicModel.SetVelocityX(_xAxisInput * playerData.Speed);
            }
            else if (playerCore.SlopeAnaliser.IsOnSlope && playerCore.SlopeAnaliser.CanWalkOnSlope)
            {
                var newVel = new Vector2(playerCore.SlopeAnaliser.SlopeNormalPerp.x * -_xAxisInput, playerCore.SlopeAnaliser.SlopeNormalPerp.y * -_xAxisInput) * playerData.Speed;
                playerCore.PhysicModel.SetVelocityX(newVel.x);
                playerCore.PhysicModel.SetVelocityY(newVel.y);
            }

        }

        protected override void DoChecks()
        {
            base.DoChecks();
            if (!playerCore.SlopeAnaliser.IsOnSlope && 
                !playerCore.SlopeAnaliser.CanWalkOnSlope)
            {
                playerCore.PhysicModel.ChangePhysicsMaterial(_noneFriction);
            }
        }

    }
}
