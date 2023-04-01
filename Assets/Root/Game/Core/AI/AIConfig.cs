using UnityEngine;

namespace Root.PixelGame.Game.AI
{
    internal interface IAIConfig
    {
        float UpdateFrameRate { get; }
        float MinSqrDistance { get; }
    }

    [CreateAssetMenu(fileName =nameof(AIConfig), menuName = "Configs/Enemy/AI" + nameof(AIConfig))]
    internal class AIConfig :ScriptableObject,  IAIConfig
    {
        [field: SerializeField] public float UpdateFrameRate { get; private set; }
        [field: SerializeField] public float MinSqrDistance { get; private set; }
    }
}
