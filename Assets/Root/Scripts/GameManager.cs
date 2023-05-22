using PixelGame.Components;
using PixelGame.Game;
using PixelGame.Game.Enemy;
using PixelGame.Game.Items;
using PixelGame.Game.Machines;
using PixelGame.Game.UI;
using PixelGame.Tool;
using UnityEngine;

namespace PixelGame
{
    internal class GameManager : MonoBehaviour
    {
        [Header("Player Components")]
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerUI _playerUI;

        [Header("Enemies Components")]
        [SerializeField] private EnemyView[] _enemyViews;

        [Header("In Level Components")]
        [SerializeField] private CoinView[] _coins;
        [SerializeField] private ElevatorView _elevatorView;
        [SerializeField] private DeathZonesComponent _deathZones;
        [SerializeField] private LevelObjecTriggerComponent _gameEnd;

        [Header("Game End Component")]
        [SerializeField] private GameEndSystem _gameEndSystem;


        private GameSystem _game = new GameSystem();

        private void Awake()
        {
            var playerSystem = CreatePlayerSystem();
            var enemiesSystem = CreateEnemiesSystem(playerSystem);
            var levelObjectsSystem = CreateLevelObjectsSystem();

            _game.Start(playerSystem, enemiesSystem, levelObjectsSystem, _gameEndSystem);
        }

        private void Update()
        {
            _game.WorkUpdate();
        }

        private void FixedUpdate()
        {
            _game.WorkFixedUpdate();
        }

        private PlayerGameSystem CreatePlayerSystem() => 
            new PlayerGameSystem(_playerView, _playerUI, _coins);

        private EnemiesGameSystem CreateEnemiesSystem(PlayerGameSystem playerSystem) => 
            new EnemiesGameSystem(_playerView.Transform, playerSystem.AddPoints, _enemyViews);

        private LevelObjectsGameSystem CreateLevelObjectsSystem() =>
            new LevelObjectsGameSystem(_elevatorView, _deathZones, _gameEnd);

    }
}
