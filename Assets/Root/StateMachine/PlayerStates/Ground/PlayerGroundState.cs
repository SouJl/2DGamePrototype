using Root.PixelGame.Game;

namespace Root.PixelGame.StateMachine
{
    internal class PlayerGroundState : PlayerState
    {
        public PlayerGroundState(
            IStateMachine stateMachine, 
            IPlayerStateHandler stateHandler, 
            IPlayerData playerData) : base(stateMachine, stateHandler, playerData)
        {
        }
    }
}
