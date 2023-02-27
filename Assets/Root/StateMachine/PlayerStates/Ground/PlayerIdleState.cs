using Root.PixelGame.Game;

namespace Root.PixelGame.StateMachine
{
    internal class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(
            IStateMachine stateMachine,
            IPlayerStateHandler stateHandler,
            IPlayerData playerData) : base(stateMachine, stateHandler, playerData)
        {
        }
    }
}
