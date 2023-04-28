using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Weapon;
using System;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class EnemyMeleeAtackState : AttackState
    {
        private bool _isDamageDealed;
        private bool _isKnockDealed;
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
            _isDamageDealed = false;
            _isKnockDealed = false;
            animator.StartAnimation(AnimationType.Attack1);
            weapon.OnDamage += DealDamage;
            weapon.OnKnockBack += DealKnockback;
            weapon.Attack();
        }



        public override void Exit()
        {
            base.Exit();
            weapon.OnDamage -= DealDamage;
            weapon.OnKnockBack -= DealKnockback;
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

        private void DealDamage(IDamageable damageable)
        {
            if (!_isDamageDealed)
            {
                damageable.Damage(weapon.CurrentAttack.Damage);
                _isDamageDealed = true;
            }
         
        }

        private void DealKnockback(IKnockbackable knockbackable)
        {
            if (!_isKnockDealed)
            {
                knockbackable.Knockback(
                    weapon.CurrentAttack.KnockbackAngle, 
                    weapon.CurrentAttack.KnockbackStrength, 
                    core.FacingDirection);
                _isKnockDealed = true;
            }
           
        }
    }
}
