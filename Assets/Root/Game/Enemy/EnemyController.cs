using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.StateMachines;
using Root.PixelGame.StateMachines.Enemy;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyController : IExecute
    {
        void OnCollisionContact(Collider2D collision);
    }

    internal class EnemyController : BaseController, IEnemyController, IStateHandler
    {
        private readonly IEnemyView _view;
        private readonly IEnemyModel _model;
        private readonly IEnemyCore _core;
        private readonly IAnimatorController _animator;
        private readonly IStateMachine _stateMachine;

        private readonly IDictionary<StateType, IState> _states;

        public EnemyController(
            IEnemyView view, 
            IEnemyModel model,
            IEnemyCore core,
            IAnimatorController animator,
            IStateMachine stateMachine)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));
            _model
              = model ?? throw new ArgumentNullException(nameof(model));
            _core
              = core ?? throw new ArgumentNullException(nameof(core));
            _animator
              = animator ?? throw new ArgumentNullException(nameof(animator));
            _stateMachine
                = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));

            _states = CreateStates(_stateMachine);
            _stateMachine.Initialize(GetState(StateType.IdleState));

            _view.Init(this);
        }

        private IDictionary<StateType, IState> CreateStates(IStateMachine stateMachine)
        {
            var states = new Dictionary<StateType, IState>();

            states[StateType.IdleState] = new EnemyIdleState(this, stateMachine, _core, _animator);
            

            return states;
        }

        public override void Execute()
        {
            _stateMachine.CurrentState.InputData();
            _stateMachine.CurrentState.LogicUpdate();
        }

        public override void FixedExecute()
        {
            _stateMachine.CurrentState.PhysicsUpdate();
        }

        public IState GetState(StateType stateType) => _states[stateType];

        public void OnCollisionContact(Collider2D collision)
        {
            Debug.Log($"On Contact {collision.gameObject.name}");
        }
    }
}
