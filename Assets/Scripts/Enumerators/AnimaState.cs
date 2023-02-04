namespace PixelGame.Enumerators
{
    public enum AnimaState
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
        Attack      = 12,

        //For items
        InUse       = 31,
    }
}
