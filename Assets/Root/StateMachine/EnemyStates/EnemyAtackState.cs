using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;

namespace Root.PixelGame.StateMachines.Enemy
{
    internal class EnemyAtackState : EnemyState
    {
        public EnemyAtackState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IAnimatorController animator) : base(stateHandler, core, animator)
        {
        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.Attack1);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (isAnimationEnd)
            {
                ChangeState(StateType.IdleState);
                return;
            }
        }
    }
}
