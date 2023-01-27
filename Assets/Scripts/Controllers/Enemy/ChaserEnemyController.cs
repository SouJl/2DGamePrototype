using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.Model.Utils;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class ChaserEnemyController : IExecute
    {
        private  ChaserEnemyView _view;
        private SpriteAnimatorController _animatorController;
        private AbstractAIEnemyModel _model;

        public ChaserEnemyController(ChaserEnemyView view, Transform target) 
        {
            _view = view;
            var components = new ComponentsModel(_view.Transform, _view.Rigidbody, _view.Collider);

            _animatorController = new SpriteAnimatorController(_view.AnimationConfig, _view.AnimationSpeed);
            _animatorController.StartAnimation(_view.SpriteRenderer, AnimaState.Idle, true);

            _model = new ChaserEnemyModel(components, _view.SpriteRenderer, _view.AIConfig, _view.Seeker, _view.TargetLocator, target, _view.Speed, _view.ChaseBreakDistance);

        }

        public void Execute()
        {
            _animatorController.Update();
        }

        public void FixedExecute()
        {
            _model.Update(Time.fixedDeltaTime);
            _model.Move();
            _model.Rotate(Vector3.zero);
        }
    }
}
