using PixelGame.View;
using PixelGame.Controllers;
using UnityEngine;
using PixelGame.Configs;
using PixelGame.Enumerators;

namespace PixelGame 
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private AnimationConfig _animationConfig;

        private SpriteAnimatorController _animatorController;

        private void Start()
        {
            _animatorController = new SpriteAnimatorController(_animationConfig);
            _animatorController.StartAnimation(_playerView.SpriteRenderer, AnimaState.Run, true, 10);
        }

        private void Update()
        {
            _animatorController.Update();
        }
    }
}

