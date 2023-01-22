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

        public PlayerMoveState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, AnimaState animaState) : base(stateMachine, animatorController, unit, animaState)
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


            if (_isStay) stateMachine.ChangeState(_player.IdleState);
            if (_isRoll) stateMachine.ChangeState(_player.RollState);

            if (_isWallSlide) stateMachine.ChangeState(_player.WallSlideState);
            if (_isFall) stateMachine.ChangeState(_player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _player.CheckFlip(_xAxisInput);

            if (!_player.Slope.IsOnSlope)
            {
                _player.SetVelocityX(_xAxisInput);

            }
            else if (_player.Slope.IsOnSlope && _player.Slope.CanWalkOnSlope)
            {
                var newVel = new Vector2(_player.Slope.SlopeNormalPerp.x * -_xAxisInput, _player.Slope.SlopeNormalPerp.y * -_xAxisInput);
                _player.SetVelocityX(newVel.x);
                _player.SetVelocityY(newVel.y);
            }
       
        }


        protected override void DoChecks()
        {
            base.DoChecks();
            if (!_player.Slope.IsOnSlope && !_player.Slope.CanWalkOnSlope)
            {
                _rgdBody.sharedMaterial = _noneFriction;
            }
        }
    }
}
