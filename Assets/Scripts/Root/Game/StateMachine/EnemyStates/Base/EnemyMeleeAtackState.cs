using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Weapon;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class EnemyMeleeAtackState : AttackState
    {
        public EnemyMeleeAtackState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IAnimatorController animator, 
            IWeapon weapon) : base(stateHandler, core, animator, weapon)
        {
        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.Attack1);
            weapon.Attack();
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
                if (isPlayerInMinRange)
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
