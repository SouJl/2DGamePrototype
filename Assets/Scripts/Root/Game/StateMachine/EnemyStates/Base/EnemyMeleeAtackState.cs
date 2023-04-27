using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Weapon;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class EnemyMeleeAtackState : AttackState
    {
        private bool _isAttack;

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
            _isAttack = false;
            weapon.WeaponActive += ExecuteAttack;
            weapon.Attack();
        }

        public override void Exit()
        {
            base.Exit();
            weapon.WeaponActive -= ExecuteAttack;
        }

        public override void InputData()
        {
            base.InputData();
            
            if(!_isAttack)
                weapon.Attack();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();   

            if (_isAttack && isAnimationEnd)
            {
                if (isPlayerInMinRange)
                {
                    ChangeState(StateType.PlayerDetected);
                }
                else
                {
                    ChangeState(StateType.IdleState);
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

        private void ExecuteAttack() 
        {
            _isAttack = true;
            animator.StartAnimation(AnimationType.Attack1);
        }
    }
}
