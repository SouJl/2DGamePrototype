using PixelGame.View;
using PixelGame.Controllers;
using UnityEngine;
using PixelGame.Interfaces;
using System.Collections.Generic;
using PixelGame.Components;

namespace PixelGame 
{
    public class Main : MonoBehaviour
    {
        [Header("Game Objects")]
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private List<EnemyView> _enemyViews;
        [SerializeField] private CoinsView _coinsView;
        [SerializeField] private LevelContactsComponent _levelContacts;

        private ListExecuteController _executeController;

        private PlayerController _playerController;
        private EnemyLevelController _enemyLevelController;
        private CoinsController _coinsController;
        private LevelContactsController _levelContactsController;

        private void Start()
        {
            _executeController = new ListExecuteController();
            _playerController = new PlayerController(_playerView);
            _enemyLevelController = new EnemyLevelController(_enemyViews, _playerView.Transform);
            _coinsController = new CoinsController(_playerView, _coinsView);
            _levelContactsController = new LevelContactsController(_playerView, _levelContacts.LevelEndZone, _levelContacts.DeathZones, _levelContacts.StartPostion);

            _executeController.AddExecuteObject(_playerController);
            _executeController.AddExecuteObject(_enemyLevelController);
            _executeController.AddExecuteObject(_coinsController);
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

