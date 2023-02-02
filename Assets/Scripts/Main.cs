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
        [SerializeField] private JointsCollectionView _jointsCollection;
        [SerializeField] private GUIView _guiView;
        [SerializeField]
        private GenerateLevelView _generateLevelView;


        private ListExecuteController _executeController;

        private PlayerController _playerController;
        private EnemyLevelController _enemyLevelController;
        private CoinsController _coinsController;
        private LevelContactsController _levelContactsController;

        private JointsController _jointsController;

        private LevelGeneratorController _generatorLevelController;

        private void Start()
        {
            _executeController = new ListExecuteController();

            if (_playerView) 
            {
                _playerController = new PlayerController(_playerView, _guiView.HealhBar);
                _executeController.AddExecuteObject(_playerController);
            }
  
            if (_enemyViews.Count != 0) 
            {
                _enemyLevelController = new EnemyLevelController(_enemyViews, _playerView.Transform);
                _executeController.AddExecuteObject(_enemyLevelController);
            }
            if(_coinsView) 
            {
                _coinsController = new CoinsController(_playerView, _coinsView);
                _executeController.AddExecuteObject(_coinsController);
            }

            if (_levelContacts) 
            {
                _levelContactsController = new LevelContactsController(_playerView, _levelContacts.LevelEndZone, _levelContacts.DeathZones, _levelContacts.StartPostion);
            }

            if (_jointsCollection) 
            {
                _jointsController = new JointsController(_jointsCollection);
                _executeController.AddExecuteObject(_jointsController);
            }

            _generatorLevelController = new LevelGeneratorController(_generateLevelView);
            _generatorLevelController.Init();
        }

        private void Update()
        {
            if (_executeController == null) return;

            while (_executeController.MoveNext())
            {
                IExecute tmp = (IExecute)_executeController.Current;
                tmp.Execute();
            }
            _executeController.Reset();
        }

        private void FixedUpdate()
        {
            if (_executeController == null) return;

            while (_executeController.MoveNext())
            {
                IExecute tmp = (IExecute)_executeController.Current;
                tmp.FixedExecute();
            }
            _executeController.Reset();
        }
    }
}

