namespace Root.PixelGame.StateMachines
{
    internal interface IStateMachine 
    {
        IState CurrentState { get; }
        void Initialize(IState initgState);
        void ChangeState(IState newState);
    }

    internal class StateMachine: IStateMachine
    {
        public IState CurrentState { get; private set; }

        public void Initialize(IState startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }

        public void ChangeState(IState newState)
        {
            if (newState == null) return;

            CurrentState.Exit();
            CurrentState = newState;
            newState.Enter();
        }
    }
}
