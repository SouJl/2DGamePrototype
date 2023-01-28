using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.Model.Utils;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class ProtectorEnemyController : IExecute
    {
        private ProtectorEnemyView _view;
        private SpriteAnimatorController _animatorController;
        private AbstractEnemyModel _model;

        public ProtectorEnemyController(ProtectorEnemyView view, Transform target)
        {
            _view = view;

            var components = new ComponentsModel(_view.Transform, _view.Rigidbody, _view.Collider);
            
            _model = new ProtectorEnemyModel(components, _view.SpriteRenderer, _view.EnemyData, _view.AIConfig, _view.Seeker, _view.ProtectedZone, target, _view.SpeedMuliplier);

            _animatorController = new SpriteAnimatorController(_view.EnemyData.animationConfig, _view.EnemyData.animationSpeed);
            _animatorController.StartAnimation(_view.SpriteRenderer, AnimaState.Idle, true);
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
