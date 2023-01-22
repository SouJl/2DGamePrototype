using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerWallSlideState : PlayerTouchingWallState
    {
        private float _wallSlidingSpeed;

        private bool _isJump;
        private bool _isGround;
        private bool _isFall;


        public PlayerWallSlideState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, AnimaState animaState, float wallSlideSpeed) : base(stateMachine, animatorController, unit, animaState)
        {
            _wallSlidingSpeed = wallSlideSpeed;
        }

        public override void Enter()
        {
            base.Enter();

            _rgdBody.velocity = Vector2.zero;
            _rgdBody.angularVelocity = 0;

            _isJump = false;
            _isGround = false;
        }

        public override void Exit()
        {
            base.Exit();

            _isJump = false;
            _isGround = false;
            _isFall = false;

            _jumpModel.IsWallJump = true;
        }

        public override void InputData()
        {
            base.InputData();
            _isJump = Input.GetKey(KeyCode.Space);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isGround) stateMachine.ChangeState(_player.IdleState);
            if (_isJump) stateMachine.ChangeState(_player.JumpState);
            if (_isFall) stateMachine.ChangeState(_player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _rgdBody.sharedMaterial = _noneFriction;

        }
    }
}
