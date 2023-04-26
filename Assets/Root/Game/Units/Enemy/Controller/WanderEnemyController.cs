using Root.PixelGame.Animation;
using Root.PixelGame.Components.Core;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Weapon;
using Root.PixelGame.Game.StateMachines;
using Root.PixelGame.Game.StateMachines.Enemy;
using Root.PixelGame.Tool;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class WanderEnemyController : BaseEnemyController
    {
        private readonly IWeapon _weapon;
        private IEnemyCore _core;

        public WanderEnemyController(
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

        public override void FixedExecute()
        {
            base.FixedExecute();
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
            WanderEnemyView pursuerView = view as WanderEnemyView;
            _core = CreateCore(pursuerView.Core, pursuerView.GroundCheck, pursuerView.WallCheck);
            _stateHandler = new WanderEnemyStatesHandler(_core, data, _animator);
        }

        private IEnemyCore CreateCore(IEnemyCoreComponent coreComponent, Transform groundCheck, Transform wallCheck)
        {
            IPhysicModel physic = new PhysicModel(coreComponent.Rigidbody);
            ISlopeAnaliser slopeAnaliser = new SlopeAnaliserTool(coreComponent.Rigidbody, coreComponent.Collider);
            IMove mover = new PhysicsMover(physic, data);
            IRotate rotator = new SelfRotator(coreComponent.Transform, physic);
            return new StrandingEnemyCore(coreComponent.Transform, physic, mover, rotator, slopeAnaliser, groundCheck, wallCheck, data.Speed);
        }


        private void ChangeToAttack()
        {
            _stateHandler.ChangeState(StateType.PrimaryAtackState);
        }
    }
}
