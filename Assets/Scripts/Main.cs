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

        private PlayerController _playerController;

        private void Start()
        {
            _playerController = new PlayerController(_playerView);
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

