using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using Root.PixelGame.Game.Enemy;
using System;
using UnityEngine;

namespace Root.PixelGame
{
    internal class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private AnimationDataConfig _playerAnimationConfig;
        [SerializeField] private EnemyView[] _enemyViews;

        private PlayerController _playerController;
        private EnemiesHandler _enemiesHandler; 

        private void Awake()
        {
            var playerAnimator = new SpriteAnimatorController(_playerView.SpriteRenderer, _playerAnimationConfig);

            _playerController = new PlayerController(_playerView, playerAnimator);
            _enemiesHandler = new EnemiesHandler(_playerView.Transform, _enemyViews);
        }

        private void Update()
        {
            _playerController.Execute();
            _enemiesHandler.Execute();

            if (Input.GetKey(KeyCode.Escape))
            {
                GameExit();
            }

        }

        private void FixedUpdate()
        {
            _playerController.FixedExecute();
            _enemiesHandler.FixedExecute();
        }

        private void GameExit()
        {
            Application.Quit();
        }
    }
}
