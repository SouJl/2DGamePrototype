using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    class PlayerInAirState : PlayerState
    {
        private bool _isGrounded;
        private bool _isTouchingWall;
        private bool _isGrab;

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

            /* else if (_isTouchingWall && (_xAxisInput * _player.FacingDirection) > 0) 
             {
                 stateMachine.ChangeState(_player.WallSlideState);
             }*/
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (Mathf.Abs(_xAxisInput) > player.MoveModel.MovingThresh)
            {
                player.CheckFlip(_xAxisInput);

                player.SetVelocityX(_xAxisInput);
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            _isGrounded = player.ContactsPoller.CheckGround();
            _isTouchingWall = player.ContactsPoller.CheckWallTouch();
        }
    }
}
