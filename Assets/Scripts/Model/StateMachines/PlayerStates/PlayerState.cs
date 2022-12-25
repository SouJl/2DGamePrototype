using PixelGame.Controllers;

namespace PixelGame.Model.StateMachines
{
    public class PlayerState : State
    {
        protected PlayerModel player;

        protected PlayerState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController)
        {
            player = unit as PlayerModel;
        }
    }
}
