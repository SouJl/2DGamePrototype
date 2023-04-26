namespace Root.PixelGame.StateMachines
{
    public enum StateType
    {
        IdleState,
        MoveState,
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

        PrimaryAtackState,
        SecondaryAtackState,
        TakeDamage,

        InAction,
    }
}
