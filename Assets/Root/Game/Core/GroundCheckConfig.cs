using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal interface IGroundCheckConfig
    {
        float CheckRadius { get; }
        LayerMask GroundLayerMask { get; }
    }

    [CreateAssetMenu(fileName = nameof(GroundCheckConfig), menuName = "Configs/Player/" + nameof(GroundCheckConfig))]
    internal class GroundCheckConfig : ScriptableObject, IGroundCheckConfig
    {
        [field: SerializeField] public float CheckRadius { get; private set; } = 0.3f;

        [field: SerializeField] public LayerMask GroundLayerMask { get; private set; }
    }
}
