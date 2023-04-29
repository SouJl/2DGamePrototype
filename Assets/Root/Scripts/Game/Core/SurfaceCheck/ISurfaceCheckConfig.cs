using UnityEngine;

namespace PixelGame.Game.Core
{
    internal interface ISurfaceCheckConfig
    {
        float CheckDistance { get; }
        LayerMask CheckLayerMask { get; }
    }
}
