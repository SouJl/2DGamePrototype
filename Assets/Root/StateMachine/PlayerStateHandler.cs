﻿using Root.PixelGame.Game;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerStateHandler : IStateHandler
    {
        private readonly IState idleState;
        private readonly IState runState;
        private readonly IState inAirState;
        private readonly IState landState;
        private readonly IState jumpState;
        private readonly IState fallState;
        private readonly IState wallSlideState;
        private readonly IState wallClimbState;
        private readonly IState wallGrabState;
        private readonly IState wallJumpState;
        private readonly IState ledgeState;
        private readonly IState climbState;

        private readonly IStateMachine stateMachine;

        public PlayerStateHandler(
            IStateMachine stateMachine,
            IPlayerCore playerCore,
            IPlayerData playerData)
        {
            this.stateMachine = stateMachine;

            idleState = new PlayerIdleState(this, playerCore, playerData);
            runState = new PlayerMoveState(this, playerCore, playerData);
            landState = new PlayerLandState(this, playerCore, playerData);

            this.stateMachine.Initialize(idleState);
        }

        public void ChangeState(StateType stateType) =>
            stateMachine.ChangeState(GetState(stateType));

        private IState GetState(StateType stateType)
        {
            return stateType switch
            {
                StateType.IdleState => idleState,
                StateType.RunState => runState,
                StateType.InAirState => inAirState,
                StateType.LandState => landState,
                StateType.JumpState => jumpState,
                StateType.FallState => fallState,
                StateType.WallSlideState => wallSlideState,
                StateType.WallClimbState => wallClimbState,
                StateType.WallGrabState => wallGrabState,
                StateType.WallJumpState => wallJumpState,
                StateType.LedgeState => ledgeState,
                StateType.ClimbState => climbState,
                _ => null,
            };
        }
    }
}
