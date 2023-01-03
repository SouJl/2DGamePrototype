using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerRollState : PlayerState
    {
        private float _rollFrames;
        private float _animationSpeed;
        private float _frameCount;

        private bool _isRollEnd;

        private bool _isWallSlide;
        private bool _isFall;

        public PlayerRollState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, int rollFrames, float animationSpeed) : base(stateMachine, animatorController, unit)
        {
            _rollFrames = rollFrames;
            _animationSpeed = animationSpeed;
        }

        public override void Enter()
        {
            base.Enter();
            _frameCount = 0;
            _isWallSlide = false;
            animatorController.StartAnimation(_player.SpriteRenderer, AnimaState.Roll, true);
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


            if (!_jumpModel.IsWallJump && !_player.ContactsPoller.IsGrounded && (_player.ContactsPoller.HasLeftContacts || _player.ContactsPoller.HasRightContacts))
            {
                _isWallSlide = true;
            }

            if (!_player.ContactsPoller.IsGrounded && _player.RgBody.velocity.y < -_jumpModel.FlyThershold)
            {
                _isFall = true;
            }
        }

        public override void Exit()
        {
            base.Exit();
            _isRollEnd = false;
            _isWallSlide = false;
            _isFall = false;

            _player.RgBody.velocity = Vector2.zero;
            _player.RgBody.angularVelocity = 0;
            
            animatorController.StopAnimation(_player.SpriteRenderer);
        }
    }
}
