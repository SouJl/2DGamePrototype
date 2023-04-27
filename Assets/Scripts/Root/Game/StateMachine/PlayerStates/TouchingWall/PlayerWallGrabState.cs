using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using Root.PixelGame.Game.Core;
using UnityEngine;

namespace Root.PixelGame.Game.StateMachines
{
    internal class PlayerWallGrabState : PlayerTouchingWallState
    {
        private Vector2 _holdPosition;


        public PlayerWallGrabState(
            IStateHandler stateHandler,
            IPlayerCore playerCore,
            IPlayerData playerData,
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.WallGrab);
            _holdPosition = playerCore.CurrentPosition;
            HoldPosition();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (!isExitingState)
            {
                if (_yAxisInput < 0 || !isGrab)
                {
                    ChangeState(StateType.WallSlideState);
                    return;
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if (!isExitingState)
            {
                HoldPosition();
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();
        }

        private void HoldPosition()
        {
            playerCore.CurrentPosition = _holdPosition;
            playerCore.Physic.SetVelocityX(0f);
            playerCore.Physic.SetVelocityY(0f);
        }
    }
}
