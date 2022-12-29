using PixelGame.View;
using PixelGame.Controllers;
using UnityEngine;
using PixelGame.Interfaces;
using System.Collections.Generic;

namespace PixelGame 
{
    public class Main : MonoBehaviour
    {
        [Header("Game Objects")]
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private List<EnemyView> _enemyViews;

        private ListExecuteController _executeController;

        private PlayerController _playerController;
        private EnemyLevelController _enemyLevelController;
        
        private void Start()
        {
            _executeController = new ListExecuteController();
            _playerController = new PlayerController(_playerView);
            _enemyLevelController = new EnemyLevelController(_enemyViews, _playerView.Transform);

            _executeController.AddExecuteObject(_playerController);
            _executeController.AddExecuteObject(_enemyLevelController);
        }

        private void Update()
        {
            while (_executeController.MoveNext())
            {
                IExecute tmp = (IExecute)_executeController.Current;
                tmp.Execute();
            }
            _executeController.Reset();
        }

        private void FixedUpdate()
        {
            while (_executeController.MoveNext())
            {
                IExecute tmp = (IExecute)_executeController.Current;
                tmp.FixedExecute();
            }
            _executeController.Reset();
        }
    }
}

