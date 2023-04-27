namespace Root.PixelGame.Animation
{
    internal enum AnimationType
    {
        // for Characters
        Idle        = 0,
        Run         = 1,
        InAir       = 2,
        Fall        = 3,
        Roll        = 4,
        WallSlide   = 5,
        WallGrab    = 6,
        Ledge       = 7,
        Climb       = 8,
        Attack1     = 12,
        Attack2     = 13,
        TakeDamage  = 14,

        //For items
        InUse       = 31,
        LookForPlayer = 32,
        PlayerDetected = 33,
        Charge = 34,
    }
}
