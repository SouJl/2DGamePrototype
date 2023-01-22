using PixelGame.Controllers;
using PixelGame.Enumerators;

namespace PixelGame.Model.StateMachines
{
    public class PlayerWallClimbState : PlayerTouchingWallState
    {
        public PlayerWallClimbState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, AnimaState animaState) : base(stateMachine, animatorController, unit, animaState)
        {

        }
    }
}
