using PixelGame.Animation;
using PixelGame.Components.Core;
using PixelGame.Game.Core;
using PixelGame.Game.Weapon;
using PixelGame.Game.StateMachines;
using PixelGame.Game.StateMachines.Enemy;
using PixelGame.Tool;
using System;
using UnityEngine;
using PixelGame.Tool.PlayerSearch;
using PixelGame.Tool.Audio;

namespace PixelGame.Game.Enemy
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
            AudioManager.Instance.PlaySFX(SFXAudioType.Enemy, "EnemyHit");
            _stateHandler.ChangeState(StateType.TakeDamage);
        }

        public override void Knockback(Vector2 angle, float strength, int direction)
        {
            _core.Physic.SetVelocity(strength, angle, direction);
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
            _stateHandler = new WanderEnemyStatesHandler(_core, data, _animator, _weapon);
        }

        private IEnemyCore CreateCore(IEnemyCoreComponent coreComponent, Transform groundCheck, Transform wallCheck)
        {
            IPhysicModel physic = new PhysicModel(coreComponent.Rigidbody);
            IPlayerDetection playerDetection = new PlayerDetectionTool(coreComponent.PlayerDetection);
            ISlopeAnaliser slopeAnaliser = new SlopeAnaliserTool(coreComponent.Rigidbody, coreComponent.Collider);
            IMove mover = new PhysicsMover(physic, data);
            IRotate rotator = new SelfRotator(coreComponent.Transform, physic);
            return new WanderEnemyCore(coreComponent.Transform, physic, playerDetection, mover, rotator, slopeAnaliser, groundCheck, wallCheck);
        }
    }
}
