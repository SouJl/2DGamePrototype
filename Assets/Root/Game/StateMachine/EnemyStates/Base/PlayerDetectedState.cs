using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class PlayerDetectedState : State
    {
        public PlayerDetectedState(
            IStateHandler stateHandler,
            IAnimatorController animator,
            IEnemyCore core) : base(stateHandler)
        {
        }

        protected override void DoChecks()
        {
            throw new System.NotImplementedException();
        }
    }
}
