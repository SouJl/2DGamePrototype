﻿using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Game.StateMachines;
using PixelGame.Tool;
using System;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    internal class PatrolEnemyController : BaseEnemyController
    {
        private readonly ITargetSelector _targetSelector;

        public PatrolEnemyController(
            IEnemyView view, 
            IEnemyData data, 
            IEnemyModel model,
            ITargetSelector targetSelector) : base(view, data, model)
        {
            _targetSelector
              = targetSelector ?? throw new ArgumentNullException(nameof(targetSelector));
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void FixedExecute()
        {
            base.FixedExecute();
        }

        public override void OnCollisionContact(Collider2D collision) 
        {

        }

        public override void Damage(float amount)
        {
            model.Health.DecreaseHealth(amount);

            _stateHandler.ChangeState(StateType.TakeDamage);
        }

        public override void Knockback(Vector2 angle, float strength, int direction)
        {
            Debug.Log($"{nameof(ProtectorEnemyController)}: Knockback");
        }


        protected override void CreateAnimatorController(IEnemyView view)
        {
           var animationView = view as EnemyView;
            _animator 
                = new SpriteAnimatorController(animationView.Animation.SpriteRenderer, animationView.Animation.AnimationConfig);
        }

        protected override void CreateStatesHandler(IEnemyView view)
        {
            PatrolEnemyView patrolView = view as PatrolEnemyView;
            var coreFactory = new EnemyCoreFactory(data, _targetSelector);
            IEnemyCore core = coreFactory.GetCore(patrolView.CoreComponent);

            _stateHandler = new EnemyStatesHandler(core, data,  _animator);
        }
    }
}
