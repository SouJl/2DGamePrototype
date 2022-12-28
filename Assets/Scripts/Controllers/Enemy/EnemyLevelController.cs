using PixelGame.Interfaces;
using PixelGame.View;
using System.Collections.Generic;

namespace PixelGame.Controllers
{
    public class EnemyLevelController : IExecute
    {
        private EnemyControllerFactory _enemyControllerFactory;
        private List<IExecute> _enemyControllers;

        public EnemyLevelController(List<EnemyView> enemies) 
        {
            _enemyControllerFactory = new EnemyControllerFactory();
            _enemyControllers = new List<IExecute>();

            foreach(var eView in enemies) 
            {
                _enemyControllers.Add(_enemyControllerFactory.GetEnemyController(eView));
            }
        }

        public void Execute()
        {
            foreach(var enemy in _enemyControllers) 
            {
                enemy.Execute();
            }
        }

        public void FixedExecute()
        {
            foreach (var enemy in _enemyControllers)
            {
                enemy.FixedExecute();
            }
        }
    }
}
