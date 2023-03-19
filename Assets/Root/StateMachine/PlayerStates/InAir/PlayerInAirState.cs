using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerInAirState : PlayerState
    {
        private bool _isGrounded;
        private bool _isJump;
        private bool _isTouchingWall;
        private bool _isTouchingWallBack;
        private bool _isGrab;
        private bool _isTouchingLedge;

        public PlayerInAirState(
            IStateHandler stateHandler, 
            IPlayerCore playerCore, 
            IPlayerData playerData, 
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
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
            _isJump = false;
        }

        public override void InputData()
        {
            base.InputData();
            _isJump = Input.GetKeyDown(KeyCode.Space);
            _isGrab = Input.GetKey(KeyCode.LeftControl);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();


            if (_isTouchingWall && _isGrab)
            {
                ChangeState(StateType.WallGrabState);
                return;
            }

            if (playerCore.Physic.Rigidbody.velocity.y < 0.01f)
            {
                if (_isGrounded)
                {
                    ChangeState(StateType.LandState);
                }
                else
                {
                    ChangeState(StateType.FallState);
                }
                return;
            }

            if (_isTouchingWall && !_isTouchingLedge && !_isGrounded)
            {
                ChangeState(StateType.LedgeState);
                return;
            }

            if (_isJump && (_isTouchingWall || _isTouchingWallBack))
            {
                _isTouchingWall = playerCore.WallCheck.CheckWallFront(playerCore.FacingDirection);
                playerCore.DetermineWallJumpDirection(_isTouchingWall);
                ChangeState(StateType.WallJumpState);
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
            _isTouchingWallBack = playerCore.WallCheck.CheckWallBack(playerCore.FacingDirection);
            
            _isTouchingLedge = playerCore.LedgeCheck.CheckLedgeTouch(playerCore.FacingDirection);
            if (_isTouchingWall && !_isTouchingLedge)
            {
                playerCore.LedgeCheck.LedgePosition = playerCore.CurrentPosition;
            }
        }
    }
}
