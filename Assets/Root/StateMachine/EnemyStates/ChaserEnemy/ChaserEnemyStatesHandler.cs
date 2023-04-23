using System;
using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.StateMachines.Enemy;
using System.Collections.Generic;

namespace Root.PixelGame.StateMachines
{
    internal class ChaserEnemyStatesHandler : StateHandler
    {
        private readonly IEnemyCore _chaseCore;
        private readonly IEnemyCore _patrolCore;
        private readonly IAnimatorController _animator;

        public ChaserEnemyStatesHandler(
            IEnemyCore chaseCore, 
            IEnemyCore patrolCore, 
            IAnimatorController animator) : base()
        {
            _chaseCore
              = chaseCore ?? throw new ArgumentNullException(nameof(chaseCore));
            _patrolCore
              = patrolCore ?? throw new ArgumentNullException(nameof(patrolCore));
            _animator
                = animator ?? throw new ArgumentNullException(nameof(animator));
        }

        protected override IDictionary<StateType, IState> CreateStates()
        {
            var states = new Dictionary<StateType, IState>();

            states[StateType.IdleState] = new EnemyIdleState(this, _patrolCore, _animator);
            states[StateType.InAction] = new ChaseEnemyInActionState(this, _chaseCore, _animator);
            states[StateType.TakeDamage] = new EnemyTakeDamageState(this, _chaseCore, _animator);

            return states;
        }

        protected override void Initialize()
        {
            stateMachine.Initialize(states[StateType.IdleState]);
        } 
    }
}
