using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Enemy;

namespace Root.PixelGame.StateMachines.Enemy
{
    internal class ChaserEnemyIdleState : EnemyState
    {
        public ChaserEnemyIdleState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IEnemyData data, 
            IAnimatorController animator) : base(stateHandler, core, data, animator)
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
