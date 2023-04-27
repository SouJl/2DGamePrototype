using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Weapon;
using System;

namespace Root.PixelGame.Game.StateMachines
{
    internal class PlayerAttackState : PlayerAbilityState
    {
        private readonly IWeapon _weapon;
        private readonly float _attackMoveOffset = 1.5f;

        public PlayerAttackState(
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
            Attack();
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
                playerCore.Physic.SetVelocityX(0f);
                ChangeState(StateType.IdleState);
                _weapon.WeaponActive?.Invoke();
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

        private void Attack()
        {
            playerCore.Physic.SetVelocityX(_attackMoveOffset * playerCore.FacingDirection);
            _weapon.Attack();
            _weapon.WeaponActive?.Invoke();
        }
    }
}
