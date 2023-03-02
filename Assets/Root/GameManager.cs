using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame
{
    internal class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private AnimationDataConfig _playerAnimationConfig;

        private PlayerController _playerController;


        private void Awake()
        {
            var playerAnimator = new SpriteAnimatorController(_playerView.SpriteRenderer, _playerAnimationConfig);

            _playerController = new PlayerController(_playerView, playerAnimator);
        }

        private void Update()
        {
            _playerController.Execute();
        }

        private void FixedUpdate()
        {
            _playerController.FixedExecute();
        }
    }
}
