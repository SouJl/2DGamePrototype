using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Weapon;
using System;

namespace Root.PixelGame.Game.StateMachines
{
    internal class PlayerMeleeAttackState : PlayerAbilityState
    {
        private readonly IWeapon _weapon;
        private readonly float _attackMoveOffset = 1.5f;

        private bool _isDamageDealed;
        private bool _isKnockDealed;
        
        public PlayerMeleeAttackState(
            IStateHandler stateHandler, 
            IPlayerCore playerCore, 
            IPlayerData playerData, 
            IAnimatorController animator, 
            IWeapon weapon) : base(stateHandler, playerCore, playerData, animator)
        {
            _weapon 
                = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public override void Enter()
        {
            base.Enter();
            _isDamageDealed = false;
            _isKnockDealed = false;
            _weapon.OnDamage += DealDamage;
            _weapon.OnKnockBack += DealKnockback;
            _weapon.Attack();
            playerCore.Physic.SetVelocityX(_attackMoveOffset * playerCore.FacingDirection);
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
                ChangeState(StateType.IdleState);
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
                damageable.Damage(_weapon.CurrentAttack.Damage);
                _isDamageDealed = true;
            }

        }

        private void DealKnockback(IKnockbackable knockbackable)
        {
            if (!_isKnockDealed)
            {
                knockbackable.Knockback(
                    _weapon.CurrentAttack.KnockbackAngle,
                    _weapon.CurrentAttack.KnockbackStrength,
                    playerCore.FacingDirection);
                _isKnockDealed = true;
            }

        }
    }
}
