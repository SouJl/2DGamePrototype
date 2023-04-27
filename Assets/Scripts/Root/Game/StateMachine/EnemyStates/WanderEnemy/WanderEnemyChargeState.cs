using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Enemy;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class WanderEnemyChargeState : EnemyChargeState
    {
        public WanderEnemyChargeState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IEnemyData data, 
            IAnimatorController animator) : base(stateHandler, core, data, animator)
        {

        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.Charge);
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
            if(!isGround || isDetectingWall)
            {
                ChangeState(StateType.LookForPlayerState);
                return;
            }
            if (isChargeTimeOver)
            {
                if (isPlayerInMinange)
                {
                    ChangeState(StateType.PlayerDetected);
                }
                else
                {
                    ChangeState(StateType.LookForPlayerState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
