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
        protected readonly IStateHandler stateHandler;

        public State(IStateHandler stateHandler) =>
             this.stateHandler
                = stateHandler ?? throw new ArgumentNullException(nameof(stateHandler));

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void InputData() { }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() { }

        protected abstract void DoChecks();

        protected void ChangeState(StateType newStateType) => stateHandler.ChangeState(newStateType);
    }
}
