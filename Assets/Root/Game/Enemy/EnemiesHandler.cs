using Root.PixelGame.Game.Core;
using System;
using System.Collections.Generic;

namespace Root.PixelGame.Game.Enemy
{
    internal class EnemiesHandler : IExecute
    {
        private readonly IEnemyControllerFactory _factory; 

        private List<IEnemyController> _enemiesList;
        
        public EnemiesHandler(IList<IEnemyView> enemyViews)
        {
            var enemyCoreFactory = new EnemyCoreFactory();
            _factory = new EnemyControllerFactory(enemyCoreFactory);
            _enemiesList = new List<IEnemyController>();
            foreach (var enemyView in enemyViews)
            {
                var enemyController = _factory.CreateEnemyController(enemyView);
                _enemiesList.Add(enemyController);
            }
        }

        public void Execute()
        {
            foreach (var enemy in _enemiesList)
            {
                enemy.Execute();
            }
        }

        public void FixedExecute()
        {
            foreach (var enemy in _enemiesList)
            {
                enemy.FixedExecute();
            }
        }
    }
}
