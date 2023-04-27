using UnityEngine;

namespace Root.PixelGame.Components.AI
{
    internal interface IAIComponent 
    {
        IAIData AIData { get; }
    }

    internal abstract class AIComponent : MonoBehaviour, IAIComponent
    {
        [Header("AIComponent Main Settings")]
        [SerializeField] private AIData _aIData;

        public IAIData AIData => _aIData;
        public Transform Handler => gameObject.transform;


    }
}
