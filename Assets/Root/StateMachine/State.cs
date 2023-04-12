using System;

namespace Root.PixelGame.StateMachines
{
    internal interface IState
    {
        void Enter();

        void Exit();

        void InputData();

        void LogicUpdate();

        void PhysicsUpdate();
    }

    internal abstract class State : IState
    {
        private readonly IStateHandler _stateHandler;
        private readonly IStateMachine _stateMachine;
         
        public State(
            IStateHandler stateHandler,
            IStateMachine stateMachine)
        {
            _stateHandler
             = stateHandler ?? throw new ArgumentNullException(nameof(stateHandler));
            _stateMachine
               = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine)); 
        }

        protected void ChangeState(StateType newStateType) 
            => _stateMachine.ChangeState(_stateHandler.GetState(newStateType));

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void InputData() { }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() { }

        protected abstract void DoChecks();

    }
}
