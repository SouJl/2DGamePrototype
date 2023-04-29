using PixelGame.Animation;
using PixelGame.Game;
using PixelGame.Game.Core;

namespace PixelGame.Game.StateMachines
{
    internal class PlayerHitState : PlayerState
    {
        private readonly float _hitOffsetStrength  = 1.2f;

        public PlayerHitState(
            IStateHandler stateHandler, 
            IPlayerCore playerCore,
            IPlayerData playerData, 
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {

        }
        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.TakeDamage);
            playerCore.Physic.SetVelocityX(_hitOffsetStrength * -playerCore.FacingDirection);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isAnimationEnd)
            {
                playerCore.Physic.SetVelocityX(0f);
                ChangeState(StateType.IdleState);
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();
        }

    }
}
