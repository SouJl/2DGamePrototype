using PixelGame.Controllers;
using PixelGame.Enumerators;
using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerRollState : PlayerState
    {
        private IMove _moveModel;

        private float _rollFrames;
        private float _animationSpeed;
        private float _frameCount;

        private bool _isEnd;

        public PlayerRollState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController, int rollFrames, float animationSpeed) : base(unit, stateMachine, animatorController)
        {
            _rollFrames = rollFrames;
            _animationSpeed = animationSpeed;
            _moveModel = player.MoveModel;
        }

        public override void Enter()
        {
            base.Enter();
            _frameCount = 0;
            animatorController.StartAnimation(player.SpriteRenderer, AnimaState.Roll, true);
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isEnd) stateMachine.ChangeState(player.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            var direction = player.SpriteRenderer.flipX ? -1 : 1;
            _moveModel.Move(direction);
            if (_frameCount < _rollFrames)
            {
                _frameCount += Time.fixedDeltaTime * _animationSpeed;
            }
            else
                _isEnd = true;
        }

        public override void Exit()
        {
            base.Exit();
            _isEnd = false;
            animatorController.StopAnimation(player.SpriteRenderer);
        }
    }
}
