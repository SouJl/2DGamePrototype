using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using Root.PixelGame.Game.Enemy;
using Root.PixelGame.Game.Items;
using Root.PixelGame.Game.UI;
using Root.PixelGame.Game.Weapon;
using UnityEngine;

namespace Root.PixelGame
{
    internal class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private WeaponView _playerWeapon;
        [SerializeField] private PlayerHealthUI _playerHealthUI;
        [SerializeField] private PlayerCoinsUI playerCoinsUI;

        [SerializeField] private AnimationDataConfig _playerAnimationConfig;
        [SerializeField] private EnemyView[] _enemyViews;
        [SerializeField] private CoinView[] _coins;

        private PlayerController _playerController;
        private EnemiesHandler _enemiesHandler; 

        private void Awake()
        {
            CreatePlayer();
            _enemiesHandler = new EnemiesHandler(_playerView.Transform, _enemyViews);
        }

        private void CreatePlayer()
        {
            var playerAnimator = new SpriteAnimatorController(_playerView.SpriteRenderer, _playerAnimationConfig);
            var wepon = new Sword(_playerWeapon, playerAnimator);
            var coinsController = new CoinsController(playerCoinsUI, _coins);
            _playerController = new PlayerController(_playerView, playerAnimator, wepon, _playerHealthUI, coinsController);
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
