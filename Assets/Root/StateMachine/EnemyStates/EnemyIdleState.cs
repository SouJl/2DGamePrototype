using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;

namespace Root.PixelGame.StateMachines.Enemy
{
    internal class EnemyIdleState : EnemyState
    {
        public EnemyIdleState(
            IStateHandler stateHandler, 
            IEnemyCore core,
            IAnimatorController animator) : base(stateHandler, core, animator)
        {
        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.Idle);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            core.Move(fixedTime);
            core.Rotate(fixedTime);
        }


        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
