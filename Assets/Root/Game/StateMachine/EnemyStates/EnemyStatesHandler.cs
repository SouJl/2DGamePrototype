using System;
using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.StateMachines.Enemy;
using System.Collections.Generic;
using Root.PixelGame.Game.Enemy;

namespace Root.PixelGame.Game.StateMachines
{
    internal class EnemyStatesHandler : StateHandler
    {
        private readonly IEnemyCore _core;
        private readonly IEnemyData _data;
        private readonly IAnimatorController _animator;

        public EnemyStatesHandler(
            IEnemyCore core, 
            IEnemyData data,
            IAnimatorController animator) : base()
        {
            _core
              = core ?? throw new ArgumentNullException(nameof(core));
            _data 
                = data ?? throw new ArgumentNullException(nameof(data));
            _animator
                = animator ?? throw new ArgumentNullException(nameof(animator));
        }

        protected override IDictionary<StateType, IState> CreateStates()
        {
            var states = new Dictionary<StateType, IState>();

            states[StateType.IdleState] = new EnemyIdleState(this, _core,  _data, _animator);
            states[StateType.MoveState] = new EnemyMoveState(this, _core, _data, _animator);
            states[StateType.TakeDamage] = new EnemyTakeDamageState(this, _core, _data, _animator);
            states[StateType.PrimaryAtackState] = new EnemyAtackState(this, _core, _data, _animator);

            return states;
        }

        protected override void Initialize()
        {
            stateMachine.Initialize(states[StateType.IdleState]);
        }
    }
}
