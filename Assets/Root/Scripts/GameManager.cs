using PixelGame.Animation;
using PixelGame.Components;
using PixelGame.Game;
using PixelGame.Game.Enemy;
using PixelGame.Game.Items;
using PixelGame.Game.Machines;
using PixelGame.Game.UI;
using PixelGame.Game.Weapon;
using PixelGame.Tool;
using PixelGame.Tool.Audio;
using System;
using System.Collections;
using UnityEngine;

namespace PixelGame
{
    internal class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerHealthUI _playerHealthUI;
        [SerializeField] private PlayerCoinsUI playerCoinsUI;
        [SerializeField] private GameEndComponent _gameEndUI;

        [SerializeField] private AnimationDataConfig _playerAnimationConfig;
        [SerializeField] private EnemyView[] _enemyViews;
        [SerializeField] private CoinView[] _coins;
        [SerializeField] private ElevatorView _elevatorView;
        [SerializeField] private DeathZonesComponent _deathZones;
        [SerializeField] private LevelObjecTriggerComponent _gameEnd;


        private PlayerController _playerController;
        private EnemiesHandler _enemiesHandler;
        private ElevatorController _elevatorController;

        private void Awake()
        {
            CreatePlayer();
            _enemiesHandler = new EnemiesHandler(_playerView.Transform, _playerController.AddPoints, _enemyViews);
            _elevatorController = new ElevatorController(_elevatorView);

            _deathZones.OnDeathZoneContact += RestartGame;
            _gameEnd.TriggerEnter += GameEnd;
        }

        private void Start()
        {
            AudioManager.Instance.PlayMusic("MainTheme");
            AudioManager.Instance.PlayeAmbient("WaterDrips");
        }

        private void Update()
        {
            _playerController.Execute();
            _enemiesHandler.Execute(); 
        }

        private void FixedUpdate()
        {
            _playerController.FixedExecute();
            _enemiesHandler.FixedExecute();
            _elevatorController.FixedExecute();
        }

        private void CreatePlayer()
        {
            var playerAnimator = new SpriteAnimatorController(_playerView.SpriteRenderer, _playerAnimationConfig);
            var wepon = new Sword(_playerView.Weapon, playerAnimator);
            var coinsController = new CoinsController(playerCoinsUI, _coins);
            _playerController = new PlayerController(_playerView, playerAnimator, wepon, _playerHealthUI, coinsController);
        }

        private void RestartGame()
        {
            GameSceneLoader.Instance.LoadScene(1);
        }


        private void GameEnd(Collider2D collider)
        {
            if(collider.gameObject.tag == "Player") 
            {
                _gameEndUI.ShowGameEndText();
                StartCoroutine(GameExitCoroutine());
            }
               
        }

        IEnumerator GameExitCoroutine()
        {
            yield return new WaitForSeconds(2f);
            GameSceneLoader.Instance.LoadScene(0);
            AudioManager.Instance.Music.Stop();
            AudioManager.Instance.Ambient.Stop();
        }
    }
}
