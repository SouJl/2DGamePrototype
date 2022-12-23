using PixelGame.View;
using PixelGame.Controllers;
using UnityEngine;

namespace PixelGame 
{
    public class Main : MonoBehaviour
    {
        [Header("Game Objects")]
        [SerializeField] private PlayerView _playerView;

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

