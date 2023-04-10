using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.StateMachines;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyController : IExecute
    {
        void OnCollisionContact(Collider2D collision);
    }

    internal class EnemyController : BaseController, IEnemyController
    {
        private readonly IEnemyView _view;
        private readonly IEnemyModel _model;

        private readonly IAnimatorController _animator;
        private readonly IStateMachine _stateMachine;
        private readonly IStateHandler _stateHandler;

        public EnemyController(
            IEnemyView view, 
            IEnemyModel model,
            IAnimatorController animator,
            IStateMachine stateMachine)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));
            _model
              = model ?? throw new ArgumentNullException(nameof(model));
            _animator
                = animator ?? throw new ArgumentNullException(nameof(animator));
            _stateMachine
                = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));

            _view.Init(this);
        }


        public override void Execute()
        {
            _animator.Update();
            _stateMachine.CurrentState.InputData();
            _stateMachine.CurrentState.LogicUpdate();
        }

        public override void FixedExecute()
        {
            _stateMachine.CurrentState.PhysicsUpdate();
        }


        public void OnCollisionContact(Collider2D collision)
        {
            Debug.Log($"On Contact {collision.gameObject.name}");
        }

    }
}
