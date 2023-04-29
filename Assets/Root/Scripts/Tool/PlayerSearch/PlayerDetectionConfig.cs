using UnityEngine;

namespace PixelGame.Tool.PlayerSearch
{
    internal interface IPlayerDetectionData
    {
        public float MinCheckDistance { get; }
        public float MaxCheckDistance { get; }
        public float CloseActionDistance { get; }

        public float LongRangeActionTime { get; }

        public LayerMask PlaterMask { get; }
    }

    [CreateAssetMenu(fileName = nameof(PlayerDetectionConfig), menuName = "Configs/Tool/" + nameof(PlayerDetectionConfig))]
    internal class PlayerDetectionConfig : ScriptableObject, IPlayerDetectionData
    {
        [field: SerializeField] public float MinCheckDistance { get; private set; } = 2f;
        [field: SerializeField] public float MaxCheckDistance { get; private set; } = 3f;
        [field: SerializeField] public float CloseActionDistance { get; private set; } = 1.2f;
        [field: SerializeField] public float LongRangeActionTime { get; private set; } = 1.5f;
        [field: SerializeField] public LayerMask PlaterMask { get; private set; }        
    }
}
