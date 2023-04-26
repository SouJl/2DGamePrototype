using System;
using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.StateMachines.Enemy;
using System.Collections.Generic;
using Root.PixelGame.Game.Enemy;

namespace Root.PixelGame.Game.StateMachines
{
    internal class ChaserEnemyStatesHandler : StateHandler
    {
        private readonly IEnemyCore _chaseCore;
        private readonly IEnemyCore _patrolCore;
        private readonly IEnemyData _data;
        private readonly IAnimatorController _animator;

        public ChaserEnemyStatesHandler(
            IEnemyCore chaseCore, 
            IEnemyCore patrolCore, 
            IEnemyData data,
            IAnimatorController animator) : base()
        {
            _chaseCore
              = chaseCore ?? throw new ArgumentNullException(nameof(chaseCore));
            _patrolCore
              = patrolCore ?? throw new ArgumentNullException(nameof(patrolCore));
            _data 
                = data ?? throw new ArgumentNullException(nameof(data));
            _animator
                = animator ?? throw new ArgumentNullException(nameof(animator));
        }

        protected override IDictionary<StateType, IState> CreateStates()
        {
            var states = new Dictionary<StateType, IState>();

            states[StateType.IdleState] = new ChaserEnemyIdleState(this, _patrolCore, _data, _animator);
            states[StateType.InAction] = new ChaseEnemyInActionState(this, _chaseCore, _data, _animator);
            states[StateType.TakeDamage] = new EnemyTakeDamageState(this, _chaseCore, _data, _animator);

            return states;
        }

        protected override void Initialize()
        {
            stateMachine.Initialize(states[StateType.IdleState]);
        } 
    }
}
