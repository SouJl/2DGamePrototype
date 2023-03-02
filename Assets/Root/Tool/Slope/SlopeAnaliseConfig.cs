using UnityEngine;

namespace Root.PixelGame.Tool
{
    internal interface ISlopeAnaliseConfig 
    {
        public float CheckDistance { get;}
        public float MaxAngle { get; }
        public LayerMask Mask { get; }
    }

    [CreateAssetMenu(fileName = nameof(SlopeAnaliseConfig),
        menuName = "Configs/Slope/" + nameof(SlopeAnaliseConfig))]
    internal class SlopeAnaliseConfig : ScriptableObject, ISlopeAnaliseConfig
    {
        [field: SerializeField] public float CheckDistance { get; private set; }

        [field: SerializeField] public float MaxAngle { get; private set; }

        [field: SerializeField] public LayerMask Mask { get; private set; }
    }
}
