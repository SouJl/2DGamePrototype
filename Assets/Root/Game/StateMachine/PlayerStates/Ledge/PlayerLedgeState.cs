using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using Root.PixelGame.Game.Core;
using UnityEngine;

namespace Root.PixelGame.Game.StateMachines
{
    internal class PlayerLedgeState : PlayerState
    {
        private Vector2 _cornerPos;
        private Vector2 _startPos;
        private bool _isHanging;

        public PlayerLedgeState(
            IStateHandler stateHandler,
            IPlayerCore playerCore,
            IPlayerData playerData,
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }
        public override void Enter()
        {
            base.Enter();

            playerCore.Physic.SetVelocityZero();
            playerCore.CurrentPosition = playerCore.LedgeCheck.LedgePosition;
            _cornerPos = playerCore.LedgeCheck.DetermineCornerPos(playerCore.FacingDirection);

            _startPos.Set(
                _cornerPos.x - (playerCore.FacingDirection * playerData.StartOffset.x), 
                _cornerPos.y - playerData.StartOffset.y);

            playerCore.CurrentPosition = _startPos;

            _isHanging = true;

            animator.StartAnimation(AnimationType.Ledge);
        }


        public override void Exit()
        {
            base.Exit();
            _isHanging = false;
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if ((Mathf.Abs(_xAxisInput) > 0 && _yAxisInput > 0) && _xAxisInput * playerCore.FacingDirection > 0)
            {
                ChangeState(StateType.ClimbState);
                return;
            }

            if (_isHanging && _yAxisInput < -playerData.FallThreshold)
            {
                ChangeState(StateType.WallSlideState);
                return;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            playerCore.Physic.SetVelocityZero();
            playerCore.CurrentPosition = _startPos;
        }
        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
