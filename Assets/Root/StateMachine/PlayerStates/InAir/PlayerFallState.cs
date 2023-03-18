﻿using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerFallState : PlayerState
    {
        private bool _isGrounded;
        private bool _isTouchingWall;

        public PlayerFallState(
            IStateHandler stateHandler, 
            IPlayerCore playerCore, 
            IPlayerData playerData, 
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.Fall);
        }


        public override void Exit()
        {
            base.Exit();
            _isGrounded = false;
            _isTouchingWall = false;
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isGrounded)
            {
                ChangeState(StateType.LandState);
                return;
            }

            if (_isTouchingWall && (_xAxisInput * playerCore.FacingDirection) > 0)
            {
                ChangeState(StateType.WallSlideState);
                return;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (Mathf.Abs(_xAxisInput) > playerData.MoveThresh)
            {
                playerCore.CheckFlip(_xAxisInput);

                playerCore.Physic.SetVelocityX(_xAxisInput * playerData.Speed);
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            _isGrounded = playerCore.GroundCheck.CheckGround();
            _isTouchingWall = playerCore.WallCheck.CheckWallFront(playerCore.FacingDirection);
        }
    }
}
