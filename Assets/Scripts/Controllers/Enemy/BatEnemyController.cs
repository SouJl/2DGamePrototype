using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using System;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class BatEnemyController : IExecute, IDisposable
    {
        private AbstractEnemyModel _enemy;
        private BatEnemyView _view;
        private SpriteAnimatorController _animatorController;

        public BatEnemyController(BatEnemyView view, AbstractEnemyModel enemyModel) 
        {
            _view = view;
            _enemy = enemyModel;

            _animatorController = new SpriteAnimatorController(_view.AnimationConfig, _view.AnimationSpeed);
            _animatorController.StartAnimation(_view.SpriteRenderer, AnimaState.Idle, true);

            _view.OnLevelObjectContact += OnCloseContact;
            _view.Locator.OnLacatorContact += OnLocatorContact;
        }

        public void Execute()
        {
            _animatorController.Update();
        }

        public void FixedExecute()
        {
            
        }

        public void OnLocatorContact(LevelObjectView target)
        {
            _enemy.Rotate();

            if (_enemy.CanAttack())
            {
                _enemy.Attack();         
            }
        }

        public void OnCloseContact(LevelObjectView target)
        {
            Debug.Log($"{this} close contact {target.gameObject.tag}");
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnCloseContact;
            _view.Locator.OnLacatorContact -= OnLocatorContact;
        }
    }
}
