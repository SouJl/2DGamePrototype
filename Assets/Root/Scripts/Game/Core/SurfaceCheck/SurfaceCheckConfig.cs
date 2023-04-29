using UnityEngine;

namespace PixelGame.Game.Core
{
    [CreateAssetMenu(fileName = nameof(SurfaceCheckConfig), menuName = "Configs/Player/" + nameof(SurfaceCheckConfig))]
    internal class SurfaceCheckConfig : ScriptableObject, ISurfaceCheckConfig
    {
        [field: SerializeField] public float CheckDistance { get; private set; } = 0.3f;

        [field: SerializeField] public LayerMask CheckLayerMask { get; private set; }
    }
}
