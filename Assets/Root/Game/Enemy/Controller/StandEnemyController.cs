using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.StateMachines;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class StandEnemyController : BaseEnemyController
    {
        public StandEnemyController(
            IEnemyView view, 
            IEnemyData data, 
            IEnemyModel model) : base(view, data, model)
        {
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
            _stateHandler = new EnemyStatesHandler(new StubEnemyCore(nameof(StandEnemyController)), _animator);
        }
    }
}
