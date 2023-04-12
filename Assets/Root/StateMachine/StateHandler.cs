using System;
using System.Collections.Generic;

namespace Root.PixelGame.StateMachines
{
    internal interface IStateHandler
    {
        IState GetState(StateType stateType);
    }
    internal class StateHandler : IStateHandler
    {
        private IDictionary<StateType, IState> _usedStates;

        public StateHandler(IDictionary<StateType, IState> usedStates)
        {
            _usedStates 
                = usedStates ?? throw new ArgumentNullException(nameof(usedStates));
        }


        public IState GetState(StateType stateType) 
            => _usedStates[stateType];

    }
}
