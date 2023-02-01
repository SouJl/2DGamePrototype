using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    class PlayerInAirState : PlayerState
    {
        private bool _isJump;
        private bool _isGrounded;
        private bool _isTouchingWall;
        private bool _isTouchingWallBack;
        private bool _isGrab;
        private bool _isTouchingLedge;

        public PlayerInAirState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState) : base(stateMachine, animatorController, unit, playerData, animaState)
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
            _isGrab = false;
        }

        public override void InputData()
        {
            base.InputData();
            _isGrab = Input.GetKey(KeyCode.LeftControl);
            _isJump = Input.GetKeyDown(KeyCode.Space);

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_isTouchingWall && _isGrab)
            {
                stateMachine.ChangeState(player.WallGrabState);
                return;
            }
            
            if (player.UnitComponents.RgdBody.velocity.y < 0.01f)
            {
                if (_isGrounded)
                {
                    stateMachine.ChangeState(player.LandState);
                }
                else
                {
                    stateMachine.ChangeState(player.FallState);
                }
                return;
            }

            if (_isTouchingWall && !_isTouchingLedge && !_isGrounded)
            {
                stateMachine.ChangeState(player.LedgeState);
                return;
            }

            if (_isJump && (_isTouchingWall || _isTouchingWallBack))
            {
                _isTouchingWall = player.ContactsPoller.CheckWallFront(player.FacingDirection);
                player.DetermineWallJumpDirection(_isTouchingWall);
                stateMachine.ChangeState(player.WallJumpState);
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
            _isTouchingWallBack = player.ContactsPoller.CheckWallBack(player.FacingDirection);

            _isTouchingLedge = player.ContactsPoller.CheckLedgeTouch(player.FacingDirection);


            if ( _isTouchingWall && !_isTouchingLedge)
            {
                player.SetDetectedPos(player.UnitComponents.Transform.position);
            }
        }
    }
}
