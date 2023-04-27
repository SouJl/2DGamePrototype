using System;
using UnityEngine;

namespace Root.PixelGame.Game.StateMachines
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

        public float startTime { get; protected set; }

        public State(
            IStateHandler stateHandler)
        {
            _stateHandler
             = stateHandler ?? throw new ArgumentNullException(nameof(stateHandler));
        }

        protected void ChangeState(StateType newStateType) 
            => _stateHandler.ChangeState(newStateType);

        public virtual void Enter() 
        {
            startTime = Time.time;
        }

        public virtual void Exit() { }

        public virtual void InputData() { }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() { }

        protected abstract void DoChecks();

    }
}
