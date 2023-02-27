using Root.PixelGame.Game;

namespace Root.PixelGame.StateMachine
{
    internal class PlayerMoveState : PlayerGroundState
    {
        public PlayerMoveState(
            IStateMachine stateMachine,
            IPlayerStateHandler stateHandler,
            IPlayerData playerData) : base(stateMachine, stateHandler, playerData)
        {
        }
    }
}
