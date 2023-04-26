﻿using Root.PixelGame.Animation;
using Root.PixelGame.Game.StateMachines;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyController : IExecute
    { 
        IEnemyModel Model { get; }

        void InitController();
        void DenitController();
        void OnCollisionContact(Collider2D collision);

        void TakeDamage(float amount);
    }

    internal abstract class BaseEnemyController : BaseController, IEnemyController
    {
        protected readonly IEnemyView view;
        protected readonly IEnemyData data;
        protected readonly IEnemyModel model;

        protected IAnimatorController _animator;
        protected IStateHandler _stateHandler;
        public IEnemyModel Model => model;

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
        public abstract void TakeDamage(float amount);

        public virtual void OnCollisionContact(Collider2D collision) { }

        protected abstract void CreateAnimatorController(IEnemyView view);

        protected abstract void CreateStatesHandler(IEnemyView view);

        
    }
}
