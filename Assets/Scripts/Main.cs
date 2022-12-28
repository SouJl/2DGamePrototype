using PixelGame.View;
using PixelGame.Controllers;
using UnityEngine;
using PixelGame.Interfaces;

namespace PixelGame 
{
    public class Main : MonoBehaviour
    {
        [Header("Game Objects")]
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private BatEnemyView _enemyView;

        private ListExecuteController _executeController;

        private PlayerController _playerController;
        private EnemyController _enemyController;
        
        private void Start()
        {
            _executeController = new ListExecuteController();
            _playerController = new PlayerController(_playerView);
            _enemyController = new EnemyController(_enemyView);

            _executeController.AddExecuteObject(_playerController);
            _executeController.AddExecuteObject(_enemyController);
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

