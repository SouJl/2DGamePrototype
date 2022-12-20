using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class PlayerController: IExecute
    {
        private PlayerModel _playerModel;
        private SpriteAnimatorController _animatorController;

        public PlayerController(PlayerView view) 
        {
            _playerModel = new PlayerModel(view.Rigidbody, view.MaxHealth, view.Speed);

            _animatorController = new SpriteAnimatorController(view.AnimationConfig);
            _animatorController.StartAnimation(view.SpriteRenderer, AnimaState.Run, true, view.AnimationSpeed);
        }

        public void Execute()
        {
            _animatorController.Update();
        }

        public void FixedExecute()
        {
            _playerModel.Move(Vector3.right);
        }
    }
}
