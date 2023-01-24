using PixelGame.Interfaces;
using PixelGame.Model.Utils;
using PixelGame.View;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class EnemyLevelController : IExecute
    {
        private EnemyControllerFactory _enemyControllerFactory;
        private List<IExecute> _enemyControllers;

        private ViewService _enemyViewSevice;

        public EnemyLevelController(List<EnemyView> enemies, Transform playerTransform) 
        {
            _enemyViewSevice = new ViewService();
            _enemyControllerFactory = new EnemyControllerFactory(playerTransform, _enemyViewSevice);
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
