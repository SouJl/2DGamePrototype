using System;
using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.StateMachines.Enemy;
using System.Collections.Generic;

namespace Root.PixelGame.StateMachines
{
    internal class EnemyStatesHandler : StateHandler
    {
        private readonly IEnemyCore _core;
        private readonly IAnimatorController _animator;

        public EnemyStatesHandler(
            IEnemyCore core, 
            IAnimatorController animator) : base()
        {
            _core
              = core ?? throw new ArgumentNullException(nameof(core));
            _animator
                = animator ?? throw new ArgumentNullException(nameof(animator));
        }

        protected override IDictionary<StateType, IState> CreateStates()
        {
            var states = new Dictionary<StateType, IState>();

            states[StateType.IdleState] = new EnemyIdleState(this, _core, _animator);
            states[StateType.TakeDamage] = new EnemyTakeDamageState(this, _core, _animator);

            return states;
        }

        protected override void Initialize()
        {
            stateMachine.Initialize(states[StateType.IdleState]);
        }
    }
}
