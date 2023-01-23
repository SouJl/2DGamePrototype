using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using System;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerTouchingWallState : PlayerState
    {
        protected bool isGrounded;
        protected bool isTouchingWall;
        protected bool isGrab;
        protected bool isJump;

        public PlayerTouchingWallState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState) : base(stateMachine, animatorController, unit, playerData, animaState)
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
            isGrab= false;
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
                player.DetermineWallJumpDirection(isTouchingWall);
                stateMachine.ChangeState(player.WallJumpState);
            }

            if (isGrounded && !isGrab)
            {
                stateMachine.ChangeState(player.IdleState);
            }

            if (!isTouchingWall || ((_xAxisInput * player.FacingDirection) < 0 && !isGrab))
            {
                stateMachine.ChangeState(player.InAirState);
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
            isGrounded = player.ContactsPoller.CheckGround();
            isTouchingWall = player.ContactsPoller.CheckWallTouch();
        }
    }
}
