

using PixelGame.Game.Enemy;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Tool
{
    internal class EnemiesGameSystem : IGameSystemComponent
    {
        private readonly EnemiesHandler _enemiesHandler;
        public EnemiesGameSystem(
            Transform playerTransform, 
            Action<int> OnEnemyDefeat,
            IList<IEnemyView> enemyViews) 
        {
            _enemiesHandler = new EnemiesHandler(playerTransform, OnEnemyDefeat, enemyViews);
        }

        public IExecute GetExecutable() =>
            _enemiesHandler;
    }
}
