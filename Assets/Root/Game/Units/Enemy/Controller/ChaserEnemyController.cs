using Root.PixelGame.Animation;
using Root.PixelGame.Components.AI;
using Root.PixelGame.Components.Core;
using Root.PixelGame.Game.AI;
using Root.PixelGame.Game.AI.Model;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.StateMachines;
using Root.PixelGame.Tool;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class ChaserEnemyController : BaseEnemyController
    {
        private readonly ITargetSelector _targetSelector;
        private readonly ILevelObjectTrigger _playerLocator;
        private readonly float _chaseBreakDistance;

        private IEnemyCore _core;

        private bool _isChase = false;

        public ChaserEnemyController(
            IEnemyView view,
            IEnemyData data,
            IEnemyModel model,
            ITargetSelector targetSelector,
            ILevelObjectTrigger playerLocator,
            float chaseBreakDistance) : base(view, data, model) 
        {
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

            /*if (_isChase)
            {
                var distance = Vector2.Distance(model.SelfTransform.position, _targetSelector.CurrentTarget.position);

                if (distance > _chaseBreakDistance)
                {
                    _stateHandler.ChangeState(StateType.IdleState);
                    _targetSelector.ChangeTarget(default);
                    _isChase = false;
                }
            }*/
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

        private void OnLocatorContact(Collider2D collision)
        {
            /*if(collision.gameObject.tag == "Player")
            {
                if (_isChase == true) return;

                _stateHandler.ChangeState(StateType.InAction);
                _isChase = true;
                _targetSelector.ChangeTarget(collision.gameObject.transform);
            }*/
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
            _stateHandler = new ChaserEnemyStatesHandler(_core, aiBeahaviour, data, _animator);
        }


        private IEnemyCore CreateCore(IEnemyCoreComponent coreComponent)
        {
            IPhysicModel physic = new PhysicModel(coreComponent.Rigidbody);
            IMove mover = new PhysicsMover(physic, data);
            IRotate rotator = new SelfRotator(coreComponent.Transform, physic);
            return new ChaserEnemyCore(coreComponent.Transform, physic, mover, rotator);
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
