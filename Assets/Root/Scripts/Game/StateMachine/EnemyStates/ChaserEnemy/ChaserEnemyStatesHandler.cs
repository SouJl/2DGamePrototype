using System;
using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Game.StateMachines.Enemy;
using System.Collections.Generic;
using PixelGame.Game.Enemy;
using PixelGame.Game.AI;
using PixelGame.Game.Weapon;

namespace PixelGame.Game.StateMachines
{
    internal class ChaserEnemyStatesHandler : StateHandler
    {
        private readonly IEnemyCore _core;
        private readonly IAIBehaviour _aIBehavior;
        private readonly IEnemyData _data;
        private readonly IAnimatorController _animator;
        private readonly IWeapon _weapon;

        public ChaserEnemyStatesHandler(
            IEnemyCore core, 
            IEnemyData data,
            IAnimatorController animator,
            IWeapon weapon,
            IAIBehaviour aIBehavior) : base()
        {
            _core
              = core ?? throw new ArgumentNullException(nameof(core));
            _data 
                = data ?? throw new ArgumentNullException(nameof(data));
            _animator
                = animator ?? throw new ArgumentNullException(nameof(animator));
            _weapon 
                = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _aIBehavior 
                = aIBehavior ?? throw new ArgumentNullException(nameof(aIBehavior));
        }

        protected override IDictionary<StateType, IState> CreateStates()
        {
            var states = new Dictionary<StateType, IState>();

            states[StateType.IdleState] = new ChaserEnemyIdleState(this, _core, _data, _animator, _aIBehavior);
            states[StateType.MoveState] = new ChaserEnemyMoveState(this, _core, _data, _animator, _aIBehavior);
            states[StateType.TakeDamage] = new EnemyTakeDamageState(this, _core, _data, _animator);
            states[StateType.MeleeAttackState] = new EnemyMeleeAtackState(this, _core, _animator, _weapon);

            return states;
        }

        protected override void Initialize()
        {
            stateMachine.Initialize(states[StateType.IdleState]);
        } 
    }
}
