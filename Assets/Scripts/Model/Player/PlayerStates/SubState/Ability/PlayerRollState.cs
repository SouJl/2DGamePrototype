using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerRollState : PlayerAbilityState
    {
        private float _animationSpeed;
        private float _frameCount;

        private bool _isRollEnd;

        private bool _isWallSlide;
        private bool _isFall;

        public PlayerRollState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState,float animationSpeed) : base(stateMachine, animatorController, unit, playerData, animaState)
        {
            _animationSpeed = animationSpeed;
        }

        public override void Enter()
        {
            base.Enter();
            _frameCount = 0;
            _isWallSlide = false;
        }


        public override void Exit()
        {
            base.Exit();
            _isRollEnd = false;
            _isWallSlide = false;
            _isFall = false;

            rgdBody.velocity = Vector2.zero;
            rgdBody.angularVelocity = 0;
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isRollEnd) stateMachine.ChangeState(player.IdleState);
            if (_isWallSlide) stateMachine.ChangeState(player.WallSlideState);
            if (_isFall) stateMachine.ChangeState(player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            var direction = player.SpriteRenderer.flipX ? -1 : 1;
            player.SetVelocityX(direction);
            
            if (_frameCount < playerData.rollFrames)
            {
                _frameCount += Time.fixedDeltaTime * _animationSpeed;
            }
            else
                _isRollEnd = true;
        }

    }
}
