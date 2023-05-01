using System;
using PixelGame.Animation;
using PixelGame.Game.Core;
using System.Collections.Generic;
using PixelGame.Game.Enemy;
using PixelGame.Game.Weapon;

namespace PixelGame.Game.StateMachines.Enemy
{
    internal class WanderEnemyStatesHandler : StateHandler
    {
        private readonly IEnemyCore _core;
        private readonly IEnemyData _data;
        private readonly IAnimatorController _animator;
        private readonly IWeapon _weapon;

        public WanderEnemyStatesHandler(
            IEnemyCore core,
            IEnemyData data,
            IAnimatorController animator,
            IWeapon weapon) : base()
        {
            _core
              = core ?? throw new ArgumentNullException(nameof(core));
            _data
                = data ?? throw new ArgumentNullException(nameof(data));
            _animator
                = animator ?? throw new ArgumentNullException(nameof(animator));
            _weapon 
                = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        protected override IDictionary<StateType, IState> CreateStates()
        {
            var states = new Dictionary<StateType, IState>();

            states[StateType.IdleState] = new WanderEnemyIdleState(this, _core, _data, _animator);
            states[StateType.MoveState] = new WanderEnemyMoveState(this, _core, _data, _animator);
            states[StateType.ChargeState] = new WanderEnemyChargeState(this, _core, _data, _animator);

            states[StateType.LookForPlayerState] = new WanderEnemyLookForPlayerState(this, _core, _data, _animator);
            states[StateType.PlayerDetected] = new WanderEnemyPlayerDetectedState(this, _animator, _core);
            states[StateType.MeleeAttackState] = new EnemyMeleeAtackState(this, _core, _animator, _weapon);

            states[StateType.TakeDamage] = new EnemyTakeDamageState(this, _core, _data, _animator);

            return states;
        }

        protected override void Initialize()
        {
            stateMachine.Initialize(states[StateType.IdleState]);
        }
    }
}
