using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using System;

namespace PixelGame.Controllers
{
    public class EnemyController : IExecute, IDisposable
    {
        private EnemyModel _enemy;
        private EnemyView _view;
        private SpriteAnimatorController _animatorController;

        public EnemyController(EnemyView view) 
        {
            _view = view;
            _animatorController = new SpriteAnimatorController(_view.AnimationConfig, _view.AnimationSpeed);
            _animatorController.StartAnimation(_view.SpriteRenderer, AnimaState.Idle, true);
            
            _enemy = new EnemyModel(_view.SpriteRenderer, _view.Collider, new NoneMoveModel(), new NoneJumpModel());

            _view.OnLevelObjectContact += _enemy.OnCloseContact;
            _view.Locator.OnLacatorContact += _enemy.OnLocatorContact;
        }

        public void Execute()
        {
            _animatorController.Update();
        }

        public void FixedExecute()
        {
            
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= _enemy.OnCloseContact;
            _view.Locator.OnLacatorContact -= _enemy.OnLocatorContact;
        }
    }
}
