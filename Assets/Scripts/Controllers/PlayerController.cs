using PixelGame.Interfaces;
using PixelGame.Model;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class PlayerController: IExecute
    {
        private PlayerModel _playerModel;
        private SpriteAnimatorController _animatorController;

        public PlayerController(PlayerModel playerModel, SpriteAnimatorController animatorController) 
        {
            _playerModel = playerModel;
            _animatorController = animatorController;
        }

        public void Execute()
        {
    
        }

        public void FixedExecute()
        {
            _playerModel.Move(Vector3.right);
        }
    }
}
