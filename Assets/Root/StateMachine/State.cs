namespace Root.PixelGame.StateMachine
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
        protected readonly IStateMachine stateMachine;

        public State(IStateMachine stateMachine) =>
            this.stateMachine = stateMachine;

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void InputData() { }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() { }

        protected abstract void DoChecks();

        protected void ChangeState(IState newState) => stateMachine.ChangeState(newState);
    }
}
