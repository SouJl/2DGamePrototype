using System;
using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using System.Collections.Generic;
using Root.PixelGame.Game.Core;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerStatesHandler : StateHandler
    {
        private readonly IPlayerData _data;
        private readonly IPlayerCore _core;
        private readonly IAnimatorController _animator;

        public PlayerStatesHandler(
            IPlayerData data,
            IPlayerCore core,
            IAnimatorController animator) : base()
        {
            _data
                = data ?? throw new ArgumentNullException(nameof(data));
            _core 
                = core ?? throw new ArgumentNullException(nameof(core));
            _animator
                = animator ?? throw new ArgumentNullException(nameof(animator));
        }

        protected override void Initialize()
        {
            stateMachine.Initialize(states[StateType.IdleState]);
        }

        protected override IDictionary<StateType, IState> CreateStates()
        {
            var states = new Dictionary<StateType, IState>();

            states[StateType.IdleState] = new PlayerIdleState(this, _core, _data, _animator);
            states[StateType.RunState] = new PlayerMoveState(this, _core, _data, _animator);
            states[StateType.LandState] = new PlayerLandState(this, _core, _data, _animator);
            states[StateType.InAirState] = new PlayerInAirState(this, _core, _data, _animator);
            states[StateType.JumpState] = new PlayerJumpState(this, _core, _data, _animator);
            states[StateType.FallState] = new PlayerFallState(this, _core, _data, _animator);
            states[StateType.WallSlideState] = new PlayerWallSlideState(this, _core, _data, _animator);
            states[StateType.WallJumpState] = new PlayerWallJumpState(this, _core, _data, _animator);
            states[StateType.WallGrabState] = new PlayerWallGrabState(this, _core, _data, _animator);
            states[StateType.LedgeState] = new PlayerLedgeState(this, _core, _data, _animator);
            states[StateType.ClimbState] = new PlayerClimbState(this, _core, _data, _animator);

            return states;
        }   
    }
}
