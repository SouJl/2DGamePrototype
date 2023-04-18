using Root.PixelGame.Animation;
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
        private readonly IStateHandler _stateHandler;
        public EnemyController(
            IEnemyView view, 
            IEnemyModel model,
            IAnimatorController animator,
            IStateHandler stateHandler)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));
            _model
              = model ?? throw new ArgumentNullException(nameof(model));

            _animator
              = animator ?? throw new ArgumentNullException(nameof(animator));
            _stateHandler
                = stateHandler ?? throw new ArgumentNullException(nameof(stateHandler));
           
            _stateHandler.Init();

            _view.Init(this);
        }


        public override void Execute()
        {
            _animator.Update();
            _stateHandler.Execute();
        }

        public override void FixedExecute()
        {
            _stateHandler.FixedExecute();
        }

        public void OnCollisionContact(Collider2D collision)
        {
            
        }
    }
}
