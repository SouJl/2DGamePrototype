using UnityEngine;

namespace PixelGame.Game.Machines
{
    internal interface IElevatorData 
    {
        float Speed { get; }
        float WaitTime { get; }
    }

    [CreateAssetMenu(fileName = nameof(ElevatorConfig),
        menuName = "Configs/Machines/" + nameof(ElevatorConfig))]
    internal class ElevatorConfig : ScriptableObject, IElevatorData
    {
        [field: SerializeField] public float Speed { get; private set; } = 3f;

        [field: SerializeField] public float WaitTime { get; private set; } = 2f;
    }
}
