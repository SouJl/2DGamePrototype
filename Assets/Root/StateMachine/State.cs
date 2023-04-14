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
         
        public State(
            IStateHandler stateHandler)
        {
            _stateHandler
             = stateHandler ?? throw new ArgumentNullException(nameof(stateHandler));
        }

        protected void ChangeState(StateType newStateType) 
            => _stateHandler.ChangeState(newStateType);

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void InputData() { }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() { }

        protected abstract void DoChecks();

    }
}
