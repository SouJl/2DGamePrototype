using Root.PixelGame.Animation;
using Root.PixelGame.Game;

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
        private readonly IState wallGrabState;
        private readonly IState wallJumpState;
        private readonly IState ledgeState;
        private readonly IState climbState;

        private readonly IStateMachine stateMachine;

        public PlayerStateHandler(
            IStateMachine stateMachine,
            IPlayerCore playerCore,
            IPlayerData playerData,
            IAnimatorController animator)
        {
            this.stateMachine = stateMachine;

            idleState = new PlayerIdleState(this, playerCore, playerData, animator);
            runState = new PlayerMoveState(this, playerCore, playerData, animator);
            landState = new PlayerLandState(this, playerCore, playerData, animator);
            inAirState = new PlayerInAirState(this, playerCore, playerData, animator);
            jumpState = new PlayerJumpState(this, playerCore, playerData, animator);
            fallState = new PlayerFallState(this, playerCore, playerData, animator);
            wallSlideState = new PlayerWallSlideState(this, playerCore, playerData, animator);
            wallJumpState = new PlayerWallJumpState(this, playerCore, playerData, animator);
            wallGrabState = new PlayerWallGrabState(this, playerCore, playerData, animator);
            ledgeState = new PlayerLedgeState(this, playerCore, playerData, animator);
            climbState = new PlayerClimbState(this, playerCore, playerData, animator);

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
                StateType.WallGrabState => wallGrabState,
                StateType.WallJumpState => wallJumpState,
                StateType.LedgeState => ledgeState,
                StateType.ClimbState => climbState,
                _ => null,
            };
        }
    }
}
