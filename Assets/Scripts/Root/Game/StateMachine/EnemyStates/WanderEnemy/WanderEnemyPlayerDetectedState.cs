using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class WanderEnemyPlayerDetectedState : PlayerDetectedState
    {
        public WanderEnemyPlayerDetectedState(
            IStateHandler stateHandler, 
            IAnimatorController animator, 
            IEnemyCore core) : base(stateHandler, animator, core)
        {

        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.PlayerDetected);
        }

        public override void Exit()
        {
            base.Exit();
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (performCloseRangeAction)
            {
                ChangeState(StateType.MeleeAttackState);
                return;
            }
            if (performLongRangeAction)
            {
                ChangeState(StateType.ChargeState);
                return;
            }
            if (!isPlayerInMaxRange)
            {
                ChangeState(StateType.LookForPlayerState);
                return;
            }
            if (!isGround)
            {
                core.Flip();
                ChangeState(StateType.MoveState);
                return;
            }
        }
    }
}
