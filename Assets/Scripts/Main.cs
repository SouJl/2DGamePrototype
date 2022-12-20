using PixelGame.View;
using PixelGame.Controllers;
using UnityEngine;
using PixelGame.Configs;
using PixelGame.Enumerators;
using PixelGame.Model;

namespace PixelGame 
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private AnimationConfig _animationConfig;

        private SpriteAnimatorController _animatorController;
        private PlayerController _playerController;
        private void Start()
        {
            _animatorController = new SpriteAnimatorController(_playerView.AnimationConfig);
            _animatorController.StartAnimation(_playerView.SpriteRenderer, AnimaState.Run, true, _playerView.AnimationSpeed);

            var playerModel = new PlayerModel(_playerView.Rigidbody, _playerView.MaxHealth, _playerView.Speed);

            _playerController = new PlayerController(playerModel, _animatorController);
        }

        private void Update()
        {
            _animatorController.Update();
        }

        private void FixedUpdate()
        {
            _playerController.FixedExecute();
        }
    }
}

