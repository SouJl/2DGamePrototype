using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerMoveState : PlayerGroundState
    {
        private bool _isStay;
        private bool _isRoll;

        private bool _isWallSlide;
        private bool _isFall;

        public PlayerMoveState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState) : base(stateMachine, animatorController, unit, playerData, animaState)
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
            _isRoll = false;
            _isWallSlide = false;
            _isFall = false;
        }

        public override void InputData()
        {
            base.InputData();
            _isStay = _xAxisInput == 0 ? true : false;
            _isRoll = Input.GetKey(KeyCode.LeftShift);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();


            if (_isStay) stateMachine.ChangeState(player.IdleState);
            if (_isRoll) stateMachine.ChangeState(player.RollState);

            if (_isWallSlide) stateMachine.ChangeState(player.WallSlideState);
            if (_isFall) stateMachine.ChangeState(player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            player.CheckFlip(_xAxisInput);

            if (!player.Slope.IsOnSlope)
            {
                player.SetVelocityX(_xAxisInput);

            }
            else if (player.Slope.IsOnSlope && player.Slope.CanWalkOnSlope)
            {
                var newVel = new Vector2(player.Slope.SlopeNormalPerp.x * -_xAxisInput, player.Slope.SlopeNormalPerp.y * -_xAxisInput);
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
