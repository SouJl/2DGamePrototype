using Root.PixelGame.Game;
using System;

namespace Root.PixelGame.StateMachine
{
    public enum PlayerStateType
    {
        IdleState,
        RunState,
        InAirState,
        LandState,
        JumpState,
        FallState,
        WallSlideState,
        WallClimbState,
        WallGrabState,
        WallJumpState,
        LedgeState,
        ClimbState,
    }

    internal interface IPlayerStateHandler
    {
        IState GetState(PlayerStateType stateType);
    }

    internal class PlayerStateHandler : IPlayerStateHandler
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

        public PlayerStateHandler(
            IStateMachine stateMachine,
            IPlayerData playerData)
        {
            idleState = new PlayerIdleState(stateMachine, this, playerData);
            runState = new PlayerMoveState(stateMachine, this, playerData);
            landState = new PlayerLandState(stateMachine, this, playerData);
        }

        public IState GetState(PlayerStateType stateType)
        {
            return stateType switch
            {
                PlayerStateType.IdleState => idleState,
                PlayerStateType.RunState => runState,
                PlayerStateType.InAirState => inAirState,
                PlayerStateType.LandState => landState,
                PlayerStateType.JumpState => jumpState,
                PlayerStateType.FallState => fallState,
                PlayerStateType.WallSlideState => wallSlideState,
                PlayerStateType.WallClimbState => wallClimbState,
                PlayerStateType.WallGrabState => wallGrabState,
                PlayerStateType.WallJumpState => wallJumpState,
                PlayerStateType.LedgeState => ledgeState,
                PlayerStateType.ClimbState => climbState,
                _ => null,
            };
        }
    }
}
