using Root.PixelGame.Animation;
using Root.PixelGame.Game;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerInAirState : PlayerState
    {
        public PlayerInAirState(
            IStateHandler stateHandler, 
            IPlayerCore playerCore, 
            IPlayerData playerData, 
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }

    }
}
