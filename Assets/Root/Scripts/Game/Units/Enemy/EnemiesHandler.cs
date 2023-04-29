using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    internal class EnemiesHandler : IExecute
    {
        private readonly IEnemyControllerFactory _factory; 

        private List<IEnemyController> _enemiesList;

        private event Action<int> OnAddPointsForDefeat;

        public EnemiesHandler(
            Transform playerTransform, 
            Action<int> OnEnemyDefeat,
            IList<IEnemyView> enemyViews)
        {
            _factory = new EnemyControllerFactory(playerTransform);
            
            OnAddPointsForDefeat += OnEnemyDefeat;

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
                    enemy.View.SetActive(false);
                    OnAddPointsForDefeat?.Invoke(enemy.Model.CostForDefeat);
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
