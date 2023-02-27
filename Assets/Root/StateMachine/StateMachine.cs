﻿namespace Root.PixelGame.StateMachine
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
            CurrentState.Exit();
            CurrentState = newState;
            newState.Enter();
        }
    }
}
