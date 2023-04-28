namespace Root.PixelGame.Game.StateMachines
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

        TakeDamage,
        PlayerDetected,

        MeleeAttackState,
        RangedAttackState,
        ChargeState,
        LookForPlayerState,
    }
}
