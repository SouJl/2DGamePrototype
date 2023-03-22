using System;

namespace Root.PixelGame.Game.Enemy
{
    internal class EnemyController : BaseController
    {
        private readonly IEnemyView _view;
        private readonly IEnemyModel _model;

        public EnemyController(
            IEnemyView view, 
            IEnemyModel model)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));
            _model
              = model ?? throw new ArgumentNullException(nameof(model));
        }

        public override void Execute()
        {
           
        }

        public override void FixedExecute()
        {
            
        }
    }
}
