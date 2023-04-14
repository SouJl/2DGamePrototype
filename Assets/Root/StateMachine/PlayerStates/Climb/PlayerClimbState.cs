using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerClimbState : PlayerState
    {
        private Vector2 _cornerPos;
        private Vector2 _stopPos;

        public PlayerClimbState(
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
            _stopPos.Set(
                _cornerPos.x + (playerCore.FacingDirection * playerData.StopOffset.x), 
                _cornerPos.y + playerData.StopOffset.y);

            animator.StartAnimation(AnimationType.Climb);
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

            if (isAnimationEnd)
            {
                playerCore.CurrentPosition = _stopPos;
                ChangeState(StateType.IdleState);
            }
        }


        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            playerCore.Physic.SetVelocityZero();

            playerCore.CurrentPosition = Vector2.Lerp(playerCore.CurrentPosition, _stopPos, playerData.ClimbSmooth);
        }

        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
