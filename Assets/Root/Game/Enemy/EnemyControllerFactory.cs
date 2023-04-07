using Root.PixelGame.Game.Core;
using System;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyControllerFactory
    {
        IEnemyController CreateEnemyController(IEnemyView view);
    }

    internal class EnemyControllerFactory : IEnemyControllerFactory
    {
        private readonly EnemyCoreFactory _coreFactory;

        public EnemyControllerFactory(EnemyCoreFactory coreFactory)
        {
            _coreFactory 
                = coreFactory ?? throw new ArgumentNullException(nameof(coreFactory));
        }

        public IEnemyController CreateEnemyController(IEnemyView view)
        {
            switch (view)
            {
                default:
                    return null;
                case StalkerEnemyView stalkerEnemy: 
                    {
                        IEnemyModel model = new StalkerEnemyModel();
                        IEnemyCore core = _coreFactory.GetEnemyCore(stalkerEnemy);
                        return new EnemyController(stalkerEnemy, model, core);
                    }
            }
        }
    }
}
