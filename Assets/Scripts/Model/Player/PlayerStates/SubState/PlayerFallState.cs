using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerFallState : PlayerState
    {
        private bool _isGrounded;
        private bool _isTouchingWall;
        private bool _isTouchingLedge;

        public PlayerFallState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState, bool loop) : base(stateMachine, animatorController, unit, playerData, animaState, loop)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }


        public override void Exit()
        {
            base.Exit();
            _isGrounded = false;
            _isTouchingWall = false;
            _isTouchingLedge = false;
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
                stateMachine.ChangeState(player.LandState);
                return;
            }

            if (_isTouchingWall && !_isTouchingLedge && !_isGrounded) 
            {
                stateMachine.ChangeState(player.LedgeState);
                return;
            }

            if (_isTouchingWall && (_xAxisInput * player.FacingDirection) > 0)
            {
                stateMachine.ChangeState(player.WallSlideState);
                return;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            if (Mathf.Abs(_xAxisInput) > playerData.moveThresh)
            {
                player.CheckFlip(_xAxisInput);

                player.SetVelocityX(_xAxisInput * playerData.speed);
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            _isGrounded = player.ContactsPoller.CheckGround();
            _isTouchingWall = player.ContactsPoller.CheckWallFront(player.FacingDirection);
            _isTouchingLedge = player.ContactsPoller.CheckLedgeTouch(player.FacingDirection);

            if (_isTouchingWall && !_isTouchingLedge)
            {
                player.SetDetectedPos(player.UnitComponents.Transform.position);
            }
        }
    }
}
