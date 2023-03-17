using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal interface ISurfaceCheckConfig
    {
        float CheckDistance { get; }
        LayerMask CheckLayerMask { get; }
    }
}
