using PixelGame.Controllers;

namespace PixelGame.Model.StateMachines
{
    public class PlayerJumpState : State
    {
        public PlayerJumpState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController)
        {

        }
    }
}
