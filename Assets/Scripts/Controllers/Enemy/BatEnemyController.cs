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
        private Transform _player;
        private AbstractAIEnemyModel _enemy;
        private BatEnemyView _view;
        private IWeapon _weapon;
        private SpriteAnimatorController _animatorController;

        public BatEnemyController(Transform player, BatEnemyView view, AbstractAIEnemyModel enemyModel, IWeapon weapon) 
        {
            _player = player;
            _view = view;
            _enemy = enemyModel;

            _animatorController = new SpriteAnimatorController(_view.AnimationConfig, _view.AnimationSpeed);
            _animatorController.StartAnimation(_view.SpriteRenderer, AnimaState.Idle, true);

            _view.OnLevelObjectContact += OnCloseContact;
            _view.Locator.OnLacatorContact += OnLocatorContact;

            _weapon = weapon;
        }

        public void Execute()
        {
            _animatorController.Update();
        }

        public void FixedExecute()
        {
            _weapon.Update(Time.fixedDeltaTime);
            _enemy.Update(Time.fixedDeltaTime);

            _enemy.Move();
            _enemy.Rotate(Vector3.zero);
        }

        public void OnLocatorContact(LevelObjectView target)
        {
            _weapon.Attack(_player.position);
        }

        public void OnCloseContact(LevelObjectView target)
        {
            
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnCloseContact;
            _view.Locator.OnLacatorContact -= OnLocatorContact;
        }
    }
}
