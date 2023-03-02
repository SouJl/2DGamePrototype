using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerMoveState : PlayerGroundState
    {
        private bool _isStay;

        private bool _isWallSlide;
        private bool _isFall;

        public PlayerMoveState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState, bool loop) : base(stateMachine, animatorController, unit, playerData, animaState, loop)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _isWallSlide = false;
        }

        public override void Exit()
        {
            base.Exit();
            _isStay = false;
            _isWallSlide = false;
            _isFall = false;
        }

        public override void InputData()
        {
            base.InputData();
            _isStay = _xAxisInput == 0 ? true : false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_isStay) stateMachine.ChangeState(player.IdleState);

            if (_isWallSlide) stateMachine.ChangeState(player.WallSlideState);
            if (_isFall) stateMachine.ChangeState(player.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            player.CheckFlip(_xAxisInput);

            if (!player.Slope.IsOnSlope)
            {
                player.SetVelocityX(_xAxisInput * playerData.speed);

            }
            else if (player.Slope.IsOnSlope && player.Slope.CanWalkOnSlope)
            {
                var newVel = new Vector2(player.Slope.SlopeNormalPerp.x * -_xAxisInput, player.Slope.SlopeNormalPerp.y * -_xAxisInput) * playerData.speed;
                player.SetVelocityX(newVel.x);
                player.SetVelocityY(newVel.y);
            }
       
        }


        protected override void DoChecks()
        {
            base.DoChecks();
            if (!player.Slope.IsOnSlope && !player.Slope.CanWalkOnSlope)
            {
                rgdBody.sharedMaterial = _noneFriction;
            }
        }
    }
}
