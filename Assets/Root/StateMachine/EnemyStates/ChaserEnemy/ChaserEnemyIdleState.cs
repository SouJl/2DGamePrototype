using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;

namespace Root.PixelGame.StateMachines.Enemy
{
    internal class ChaserEnemyIdleState : EnemyIdleState
    {
        public ChaserEnemyIdleState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IAnimatorController animator) : base(stateHandler, core, animator)
        {

        }
    }
}
