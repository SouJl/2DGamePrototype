using System;
using System.Collections.Generic;

namespace PixelGame.Game.StateMachines
{
    internal interface IStateHandler :IExecute
    {
        void Init();
        void ChangeState(StateType stateType);
    }

    internal abstract class StateHandler : IStateHandler, IDisposable
    {
        protected readonly IStateMachine stateMachine;
        protected IDictionary<StateType, IState> states;

        public StateHandler()
        {
            stateMachine = new StateMachine();
        }

        public void Init()
        {     
            states = CreateStates();
            Initialize();
        }

        public void ChangeState(StateType state) 
            => stateMachine.ChangeState(states[state]);

        public virtual void Dispose()
        {
            states.Clear();
            stateMachine.Dispose();
        }
        public virtual void Execute()
        {
            stateMachine.CurrentState.InputData();
            stateMachine.CurrentState.LogicUpdate();
        }

        public virtual void FixedExecute()
        {
            stateMachine.CurrentState.PhysicsUpdate();
        }

        protected abstract void Initialize();
        protected abstract IDictionary<StateType, IState> CreateStates();

   
    }
}
