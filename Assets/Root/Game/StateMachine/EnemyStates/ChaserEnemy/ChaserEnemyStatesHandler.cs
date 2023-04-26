using System;
using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.StateMachines.Enemy;
using System.Collections.Generic;
using Root.PixelGame.Game.Enemy;
using Root.PixelGame.Game.AI;

namespace Root.PixelGame.Game.StateMachines
{
    internal class ChaserEnemyStatesHandler : StateHandler
    {
        private readonly IEnemyCore _core;
        private readonly IAIBehaviour _aIBehavior;
        private readonly IEnemyData _data;
        private readonly IAnimatorController _animator;

        public ChaserEnemyStatesHandler(
            IEnemyCore core, 
            IAIBehaviour aIBehavior,
            IEnemyData data,
            IAnimatorController animator) : base()
        {
            _core
              = core ?? throw new ArgumentNullException(nameof(core));
            _aIBehavior
              = aIBehavior ?? throw new ArgumentNullException(nameof(aIBehavior));
            _data 
                = data ?? throw new ArgumentNullException(nameof(data));
            _animator
                = animator ?? throw new ArgumentNullException(nameof(animator));
        }

        protected override IDictionary<StateType, IState> CreateStates()
        {
            var states = new Dictionary<StateType, IState>();

            states[StateType.IdleState] = new ChaserEnemyIdleState(this, _core, _data, _animator, _aIBehavior);
            states[StateType.MoveState] = new ChaserEnemyMoveState(this, _core, _data, _animator, _aIBehavior);
            states[StateType.TakeDamage] = new EnemyTakeDamageState(this, _core, _data, _animator);

            return states;
        }

        protected override void Initialize()
        {
            stateMachine.Initialize(states[StateType.IdleState]);
        } 
    }
}
