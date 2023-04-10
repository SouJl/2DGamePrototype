using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.StateMachines.Enemy;

namespace Root.PixelGame.StateMachines
{
    internal class EnemyStateHandler : IStateHandler
    {
        private readonly IState idleState;

        private readonly IStateMachine _stateMachine;
        
        public EnemyStateHandler(
            IStateMachine stateMachine,
            IEnemyCore core,
            IAnimatorController animator)
        {
            _stateMachine = stateMachine;

            idleState = new EnemyIdleState(this, core, animator);

            _stateMachine.Initialize(idleState);
        }

        public void ChangeState(StateType stateType) =>
            _stateMachine.ChangeState(GetState(stateType));

        private IState GetState(StateType stateType)
        {
            return stateType switch
            {
                StateType.IdleState => idleState,
                _ => null,
            };
        }
    }
}
