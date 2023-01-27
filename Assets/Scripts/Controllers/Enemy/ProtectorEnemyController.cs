using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class ProtectorEnemyController : IExecute
    {
        private ProtectorEnemyView _view;
        private SpriteAnimatorController _animatorController;
        private AbstractAIEnemyModel _enemyModel;

        public ProtectorEnemyController(ProtectorEnemyView view, AbstractAIEnemyModel enemyModel)
        {
            _view = view;
            _enemyModel = enemyModel;

            _animatorController = new SpriteAnimatorController(_view.EnemyData.animationConfig, _view.EnemyData.animationSpeed);
            _animatorController.StartAnimation(_view.SpriteRenderer, AnimaState.Idle, true);
        }

        public void Execute()
        {
            _animatorController.Update();
        }

        public void FixedExecute()
        {
            _enemyModel.Update(Time.fixedDeltaTime);
            _enemyModel.Move();
            _enemyModel.Rotate(Vector3.zero);
        }
    }
}
