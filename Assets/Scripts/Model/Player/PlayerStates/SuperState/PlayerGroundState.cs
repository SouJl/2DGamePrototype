using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerGroundState : PlayerState
    {
        private bool _isJump;
        private bool _isGrounded;
        private bool _isTouchingWall;
        private bool _isGrab;

        public PlayerGroundState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState) : base(stateMachine, animatorController, unit, playerData, animaState)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
            _isJump = false;
            _isTouchingWall = false;
            _isGrab = false;
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
            if (_isJump)
            {
                stateMachine.ChangeState(player.JumpState);
                return;
            }
            if (!_isGrounded && player.CurrentVelocity.y <= 0) 
            {
                stateMachine.ChangeState(player.FallState);
                return;
            }
            if(_isTouchingWall && _isGrab) 
            {
                stateMachine.ChangeState(player.WallGrabState);
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
            _isGrounded = player.ContactsPoller.CheckGround();
            _isTouchingWall = player.ContactsPoller.CheckWallTouch();
        }
    }
}
