using Root.PixelGame.Animation;
using Root.PixelGame.StateMachines;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class ChaserEnemyController : BaseController, IEnemyController
    {
        private readonly IEnemyView _view;
        private readonly IEnemyModel _model;
        private readonly IAnimatorController _animator;
        private readonly IStateHandler _stateHandler;
        private readonly ILevelObjectTrigger _playerLocator;
        private readonly float _chaseBreakDistance;

        private Transform _target;
        private bool _isChase = false;


        public ChaserEnemyController(
            IEnemyView view,
            IEnemyModel model,
            IAnimatorController animator,
            IStateHandler stateHandler,
            ILevelObjectTrigger playerLocator,
            float chaseBreakDistance)
        {
            _view
                = view ?? throw new ArgumentNullException(nameof(view));
            _model
              = model ?? throw new ArgumentNullException(nameof(model));

            _animator
              = animator ?? throw new ArgumentNullException(nameof(animator));
            
            _stateHandler
                = stateHandler ?? throw new ArgumentNullException(nameof(stateHandler));
            
            _playerLocator 
                = playerLocator ?? throw new ArgumentNullException(nameof(playerLocator));
            _playerLocator.TriggerEnter += OnLocatorContact;

            _chaseBreakDistance = chaseBreakDistance;
            _stateHandler.Init();

            _view.Init(this);

            _target = default;
        }


        public override void Execute()
        {
            _animator.Update();
            _stateHandler.Execute();
        }

        public override void FixedExecute()
        {
            _stateHandler.FixedExecute();
            if (_isChase)
            {
                var distance = Vector2.Distance(_model.SelfTransform.position, _target.position);

                if (distance > _chaseBreakDistance)
                {
                    _stateHandler.ChangeState(StateType.IdleState);
                    _isChase = false;
                    _target = default;
                }
            }
        }

        public void OnCollisionContact(Collider2D collision)
        {

        }

        private void OnLocatorContact(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                _stateHandler.ChangeState(StateType.InAction);
                _isChase = true;
                _target = collision.gameObject.transform;
            }
        }
    }
}
