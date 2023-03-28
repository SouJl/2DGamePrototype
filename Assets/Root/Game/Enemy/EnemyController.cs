using Root.PixelGame.Game.Core;
using System;

namespace Root.PixelGame.Game.Enemy
{
    internal class EnemyController : BaseController
    {
        private readonly IEnemyView _view;
        private readonly IEnemyModel _model;
        private readonly IEnemyCore _core;

        public EnemyController(
            IEnemyView view, 
            IEnemyModel model,
            IEnemyCore core)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));
            _model
              = model ?? throw new ArgumentNullException(nameof(model));
            _core 
                = core ?? throw new ArgumentNullException(nameof(core));

        }

        public override void Execute()
        {
           
        }

        public override void FixedExecute()
        {
            _core.Move(fixedTime);
            _core.Rotate(fixedTime);
        }
    }
}
