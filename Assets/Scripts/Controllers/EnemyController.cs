

using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.View;

namespace PixelGame.Controllers
{
    public class EnemyController : IExecute
    {

        private EnemyView _view;
        private SpriteAnimatorController _animatorController;

        public EnemyController(EnemyView view) 
        {
            _view = view;
            _animatorController = new SpriteAnimatorController(_view.AnimationConfig, _view.AnimationSpeed);
            _animatorController.StartAnimation(_view.SpriteRenderer, AnimaState.Idle, true);
        }

        public void Execute()
        {
            _animatorController.Update();
        }

        public void FixedExecute()
        {
            
        }
    }
}
