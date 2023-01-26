using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class WizardController : IExecute
    {
        private WizzardEnemyView _enemyView;
        private SpriteAnimatorController _animatorController;
        private AbstractAIEnemyModel _enemyModel;

        public WizardController(WizzardEnemyView view, AbstractAIEnemyModel enemyModel)
        {
            _enemyView = view;
            _enemyModel = enemyModel;

            _animatorController = new SpriteAnimatorController(_enemyView.AnimationConfig, _enemyView.AnimationSpeed);
            _animatorController.StartAnimation(_enemyView.SpriteRenderer, AnimaState.Idle, true);

        }

        public void Execute()
        {
            _animatorController.Update();
            _enemyModel.Update(Time.deltaTime);
        }

        public void FixedExecute()
        {     
            _enemyModel.Move();
            _enemyModel.Rotate(Vector3.zero);
        }
    }
}
