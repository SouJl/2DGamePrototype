using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Game.StateMachines;
using System;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    internal interface IEnemyController : IExecute, IDamageable, IKnockbackable
    {
        IEnemyView View { get; }
        IEnemyModel Model { get; }

        void InitController();
        void DenitController();
        void OnCollisionContact(Collider2D collision);
    }

    internal abstract class BaseEnemyController : BaseController, IEnemyController
    {
        protected readonly IEnemyView view;
        protected readonly IEnemyData data;
        protected readonly IEnemyModel model;

        protected IAnimatorController _animator;
        protected IStateHandler _stateHandler;
        public IEnemyModel Model => model;

        public IEnemyView View => view;

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

        public void DenitController()
        {

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
        public abstract void Damage(float amount);

        public abstract void Knockback(Vector2 angle, float strength, int direction);

        public virtual void OnCollisionContact(Collider2D collision) { }

        protected abstract void CreateAnimatorController(IEnemyView view);

        protected abstract void CreateStatesHandler(IEnemyView view);   
    }
}
