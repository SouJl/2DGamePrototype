using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.StateMachines;
using Root.PixelGame.Tool;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class ProtectorEnemyController : BaseEnemyController
    {
        private readonly ITargetSelector _targetSelector;
        private readonly ILevelObjectTrigger _playerLocator;

        private bool _onProtect;

        public ProtectorEnemyController(
            IEnemyView view, 
            IEnemyData data, 
            IEnemyModel model,
            ITargetSelector targetSelector,
            ILevelObjectTrigger playerLocator) : base(view, data, model)
        {
            _targetSelector 
                = targetSelector ?? throw new ArgumentNullException(nameof(targetSelector));
            _playerLocator
                = playerLocator ?? throw new ArgumentNullException(nameof(playerLocator));

            _playerLocator.TriggerEnter += OnZoneEnter;
            _playerLocator.TriggerExit += OnZoneExit;

            _onProtect = false;
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

        public override void TakeDamage(float amount)
        {

        }

        protected override void CreateAnimatorController(IEnemyView view)
        {
            var animationView = view as EnemyView;
            _animator
                = new SpriteAnimatorController(animationView.Animation.SpriteRenderer, animationView.Animation.AnimationConfig);
        }

        protected override void CreateStatesHandler(IEnemyView view)
        {
            ProtectorEnemyView chaserView = view as ProtectorEnemyView;
            var coreFactory = new EnemyCoreFactory(data, _targetSelector);
            IEnemyCore chaseCore = coreFactory.GetCore(chaserView.ChaseAICore);
            IEnemyCore patrolCore = coreFactory.GetCore(chaserView.PatrolAICore);

            _stateHandler = new ChaserEnemyStatesHandler(chaseCore, patrolCore, data, _animator);
        }

        private void OnZoneEnter(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _stateHandler.ChangeState(StateType.InAction);
                _onProtect = true;
                _targetSelector.ChangeTarget(collision.gameObject.transform);
            }
        }

        private void OnZoneExit(Collider2D collision)
        {
            if (_onProtect && collision.gameObject.tag == "Player")
            {
                _stateHandler.ChangeState(StateType.IdleState);
                _onProtect = false;
                _targetSelector.ChangeTarget(default);
            }
        }

    }


}
