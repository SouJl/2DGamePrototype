using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    class PlayerInAirState : PlayerState
    {
        private bool _isGrounded;
        private bool _isTouchingWall;

        public PlayerInAirState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, AnimaState animaState) : base(stateMachine, animatorController, unit, animaState)
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
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_player.UnitComponents.RgdBody.velocity.y < 0.01f)
            {
                if (_isGrounded) 
                {
                    stateMachine.ChangeState(_player.LandState);
                }
                else 
                {
                    stateMachine.ChangeState(_player.FallState);
                }
            }
            else if (_isTouchingWall && (_xAxisInput * _player.FacingDirection) > 0) 
            {
                stateMachine.ChangeState(_player.WallSlideState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (Mathf.Abs(_xAxisInput) > _player.MoveModel.MovingThresh)
            {
                _player.CheckFlip(_xAxisInput);

                _player.SetVelocityX(_xAxisInput);
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            _isGrounded = _player.ContactsPoller.CheckGround();
            _isTouchingWall = _player.ContactsPoller.CheckWallTouch();

        }
    }
}
