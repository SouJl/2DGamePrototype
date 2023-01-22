using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerRollState : PlayerAbilityState
    {
        private float _rollFrames;
        private float _animationSpeed;
        private float _frameCount;

        private bool _isRollEnd;

        private bool _isWallSlide;
        private bool _isFall;

        public PlayerRollState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, AnimaState animaState, int rollFrames, float animationSpeed) : base(stateMachine, animatorController, unit, animaState)
        {
            _rollFrames = rollFrames;
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

            _rgdBody.velocity = Vector2.zero;
            _rgdBody.angularVelocity = 0;
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isRollEnd) stateMachine.ChangeState(_player.IdleState);
            if (_isWallSlide) stateMachine.ChangeState(_player.WallSlideState);
            if (_isFall) stateMachine.ChangeState(_player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            var direction = _player.SpriteRenderer.flipX ? -1 : 1;
            _moveModel.Move(direction);
            if (_frameCount < _rollFrames)
            {
                _frameCount += Time.fixedDeltaTime * _animationSpeed;
            }
            else
                _isRollEnd = true;

            var isGround = _player.ContactsPoller.CheckGround();

            if (!_jumpModel.IsWallJump && !isGround && (_player.ContactsPoller.HasLeftContacts || _player.ContactsPoller.HasRightContacts))
            {
                _isWallSlide = true;
            }

            if (!isGround && _rgdBody.velocity.y < -_jumpModel.FlyThershold)
            {
                _isFall = true;
            }
        }

    }
}
