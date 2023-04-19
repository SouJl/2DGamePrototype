using Root.PixelGame.Animation;
using Root.PixelGame.StateMachines;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyController : IExecute
    {
        void InitController();
        void OnCollisionContact(Collider2D collision);
    }

    internal abstract class BaseEnemyController : BaseController, IEnemyController
    {
        protected readonly IEnemyView view;
        protected readonly IEnemyData data;
        protected readonly IEnemyModel model;

        protected IAnimatorController _animator;
        protected IStateHandler _stateHandler;

        public BaseEnemyController(
            IEnemyView view, 
            IEnemyData data, 
            IEnemyModel model)
        {
            this.view
                = view ?? throw new ArgumentNullException(nameof(view));
            this.data 
                = data ?? throw new ArgumentNullException(nameof(data));
            this.model
              = model ?? throw new ArgumentNullException(nameof(model));           
        }

        public void InitController()
        {
            CreateAnimatorController(view);
            CreateStatesHandler(view);

            _stateHandler.Init();

            view.Init(this);
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

        public virtual void OnCollisionContact(Collider2D collision) { }

        protected abstract void CreateAnimatorController(IEnemyView view);

        protected abstract void CreateStatesHandler(IEnemyView view);
    }
}
