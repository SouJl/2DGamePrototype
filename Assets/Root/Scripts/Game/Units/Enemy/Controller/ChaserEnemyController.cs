using PixelGame.Animation;
using PixelGame.Components;
using PixelGame.Components.AI;
using PixelGame.Components.Core;
using PixelGame.Game.AI;
using PixelGame.Game.AI.Model;
using PixelGame.Game.Core;
using PixelGame.Game.StateMachines;
using PixelGame.Game.Weapon;
using PixelGame.Tool;
using PixelGame.Tool.Audio;
using PixelGame.Tool.PlayerSearch;
using System;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    internal class ChaserEnemyController : BaseEnemyController
    {
        private readonly IWeapon _weapon;
        private readonly ITargetSelector _targetSelector;
        private readonly ILevelObjectTrigger _playerLocator;
        private readonly float _chaseBreakDistance;

        private IEnemyCore _core;
        private bool _isChase;

        public ChaserEnemyController(
            IEnemyView view,
            IEnemyData data,
            IEnemyModel model,
            IWeapon weapon,
            ITargetSelector targetSelector,
            ILevelObjectTrigger playerLocator,
            float chaseBreakDistance) : base(view, data, model) 
        {
            _weapon
               = weapon ?? throw new ArgumentNullException(nameof(weapon));

            _targetSelector
               = targetSelector ?? throw new ArgumentNullException(nameof(targetSelector));
            _playerLocator 
                = playerLocator ?? throw new ArgumentNullException(nameof(playerLocator));
            
            _playerLocator.TriggerStay += OnLocatorContact;

            _chaseBreakDistance = chaseBreakDistance;
        }


        public override void Execute()
        {
            base.Execute();
        }

        public override void FixedExecute()
        {
            base.FixedExecute();

            if (_isChase)
            {
                var distance = Vector2.Distance(model.SelfTransform.position, _targetSelector.CurrentTarget.position);

                if (distance > _chaseBreakDistance)
                {
                    _stateHandler.ChangeState(StateType.IdleState);
                    _targetSelector.ChangeTarget(default);
                    _isChase = false;
                }
            }
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

        private void OnLocatorContact(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                if (_isChase == true) return;

                _stateHandler.ChangeState(StateType.MeleeAttackState);
                _isChase = true;
                _targetSelector.ChangeTarget(collision.gameObject.transform);
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
            ChaserEnemyView chaserView = view as ChaserEnemyView;
            _core = CreateCore(chaserView.ChaseAICore);
            IAIBehaviour aiBeahaviour = CreateAI(chaserView.ChaseAICore.AIViewComponent);
            _stateHandler = new ChaserEnemyStatesHandler(_core, data, _animator, _weapon, aiBeahaviour);
        }


        private IEnemyCore CreateCore(IEnemyCoreComponent coreComponent)
        {
            IPhysicModel physic = new PhysicModel(coreComponent.Rigidbody);
            IPlayerDetection playerDetection = new PlayerDetectionTool(coreComponent.PlayerDetection);
            IMove mover = new PhysicsMover(physic, data);
            IRotate rotator = new SelfRotator(coreComponent.Transform, physic);
            return new ChaserEnemyCore(coreComponent.Transform, physic, playerDetection, mover, rotator);
        }

        private IAIBehaviour CreateAI(IAIComponent aIViewComponent)
        {
            PatrolAIComponent patrolAI = aIViewComponent as PatrolAIComponent;
            var model = new PatrolAIModel(patrolAI.AIData, patrolAI.PatrolWayPoints, _targetSelector);
            var seeker = new PatrolPathController(
                patrolAI.Seeker,
                patrolAI.Handler,
                model);
            var aiBehavior = new PatrolAI(patrolAI.AIData, seeker, model);
            return aiBehavior;
        }

    }
}
