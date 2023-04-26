using System;
using System.Collections.Generic;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class EnemiesHandler : IExecute
    {
        private readonly IEnemyControllerFactory _factory; 

        private List<IEnemyController> _enemiesList;
        
        public EnemiesHandler(
            Transform playerTransform, 
            IList<IEnemyView> enemyViews)
        {
            _factory = new EnemyControllerFactory(playerTransform);
            _enemiesList = new List<IEnemyController>();
            foreach (var enemyView in enemyViews)
            {
                var enemyController = _factory.CreateEnemyController(enemyView);
                enemyController.InitController();
                _enemiesList.Add(enemyController);
            }
        }

        public void Execute()
        {
            CheckForAlive();
            foreach (var enemy in _enemiesList)
            {
                enemy.Execute();
            }
        }

        private void CheckForAlive()
        {
            foreach (var enemy in _enemiesList.ToArray())
            {
                if (enemy.Model.Health.CurrentHealth <= 0)
                {
                    enemy.DenitController();
                    _enemiesList.Remove(enemy);
                    continue;
                }
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
