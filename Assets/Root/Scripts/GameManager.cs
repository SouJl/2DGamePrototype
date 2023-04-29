using PixelGame.Animation;
using PixelGame.Game;
using PixelGame.Game.Enemy;
using PixelGame.Game.Items;
using PixelGame.Game.UI;
using PixelGame.Game.Weapon;
using PixelGame.Tool.Audio;
using UnityEngine;

namespace PixelGame
{
    internal class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
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
            _enemiesHandler = new EnemiesHandler(_playerView.Transform, _playerController.AddPoints, _enemyViews);

            AudioManager.Instance.PlayMusic("MainTheme");
            AudioManager.Instance.PlayeAmbient("WaterDrips");
        }

        private void CreatePlayer()
        {
            var playerAnimator = new SpriteAnimatorController(_playerView.SpriteRenderer, _playerAnimationConfig);
            var wepon = new Sword(_playerView.Weapon, playerAnimator);
            var coinsController = new CoinsController(playerCoinsUI, _coins);
            _playerController = new PlayerController(_playerView, playerAnimator, wepon, _playerHealthUI, coinsController);
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
        }
    }
}
