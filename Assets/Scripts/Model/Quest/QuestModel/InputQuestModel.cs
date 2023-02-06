using PixelGame.Interfaces;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model.Quest
{
    public enum InputAction 
    {
        Move,
        Jump,
        Ledge,
        WallJump
    }

    public class InputQuestModel : IQuestModel
    {
        private readonly PlayerModel _player;
        private readonly InputAction _action;

        private readonly string _xAxis = "Horizontal";
        private readonly string _yAxis = "Vertical";

        public InputQuestModel(PlayerModel player, InputAction action) 
        {
            _player = player;
            _action = action;
        }

        public bool TryComplete(LevelObjectView activator)
        {
            var _xInput = Input.GetAxis(_xAxis);
            var _yInput = Input.GetAxis(_yAxis);

            switch (_action) 
            {
                default:
                    return false;
                case InputAction.Move: 
                    {
                        return Mathf.Abs(_xInput) >= 1;
                    }
                case InputAction.Jump: 
                    {
                        var isJump = Input.GetKey(KeyCode.Space);       
                        return isJump;
                    }
                case InputAction.Ledge: 
                    {
                        if (_player.UnitMovementSM.CurrentState == _player.ClimbState) 
                        {
                            return true;
                        }
                        return false;
                    }
                case InputAction.WallJump: 
                    {
                        if (_player.UnitMovementSM.CurrentState == _player.WallGrabState || _player.UnitMovementSM.CurrentState == _player.WallSlideState) 
                        {
                            var isJump = Input.GetKey(KeyCode.Space);
                            return isJump;
                        }
                        return false;
                    }
            }
        }
    }
}
