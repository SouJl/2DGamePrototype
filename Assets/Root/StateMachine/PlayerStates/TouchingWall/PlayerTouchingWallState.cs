using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerTouchingWallState : PlayerState
    {
        protected bool isGrounded;
        protected bool isTouchingWall;
        protected bool isGrab;
        protected bool isJump;

        public PlayerTouchingWallState(
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
            isGrounded = false;
            isTouchingWall = false;
            isGrab = false;
        }

        public override void InputData()
        {
            base.InputData();
            isGrab = Input.GetKey(KeyCode.LeftControl);
            isJump = Input.GetKeyDown(KeyCode.Space);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isJump)
            {
                playerCore.DetermineWallJumpDirection(isTouchingWall);
                ChangeState(StateType.WallJumpState);
                return;
            }

            if (isGrounded && !isGrab)
            {
                ChangeState(StateType.IdleState);
                return;
            }

            if (!isTouchingWall || ((_xAxisInput * playerCore.FacingDirection) < 0 && !isGrab))
            {
                ChangeState(StateType.InAirState);
                return;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            isGrounded = playerCore.GroundCheck.CheckGround();
            isTouchingWall = playerCore.WallCheck.CheckWallFront(playerCore.FacingDirection);
        }
    }
}
