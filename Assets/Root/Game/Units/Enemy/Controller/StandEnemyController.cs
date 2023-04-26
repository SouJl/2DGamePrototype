using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Weapon;
using Root.PixelGame.Game.StateMachines;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class StandEnemyController : BaseEnemyController
    {
        private readonly IWeapon _weapon;

        public StandEnemyController(
            IEnemyView view, 
            IEnemyData data, 
            IEnemyModel model,
            IWeapon weapon) : base(view, data, model)
        {
            _weapon 
                = weapon ?? throw new ArgumentNullException(nameof(weapon));
            
            _weapon.WeaponActive += ChangeToAttack;
        }



        public override void Execute()
        {
            base.Execute();
            _weapon.Attack();
        }

        public override void OnCollisionContact(Collider2D collision) 
        {

        }

        public override void TakeDamage(float amount)
        {
            model.Health.DecreaseHealth(amount);
            
            _stateHandler.ChangeState(StateType.TakeDamage);

            if (model.Health.CurrentHealth == 0)
            {
                view.ChangeLevelDisplay(false);
            }
        }

        protected override void CreateAnimatorController(IEnemyView view)
        {
            var animationView = view as EnemyView;
            _animator
                = new SpriteAnimatorController(animationView.Animation.SpriteRenderer, animationView.Animation.AnimationConfig);
        }

        protected override void CreateStatesHandler(IEnemyView view)
        {
            _stateHandler = new EnemyStatesHandler(new StubEnemyCore(nameof(StandEnemyController)), data, _animator);
        }

        private void ChangeToAttack()
        {
            _stateHandler.ChangeState(StateType.PrimaryAtackState);
        }
    }
}
