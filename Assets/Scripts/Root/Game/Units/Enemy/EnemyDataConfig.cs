using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyData
    {
        float MaxHealth { get; }
        float Speed { get; }
        float MoveThresh { get; }
        float MinIdleTime { get; }
        float MaxIdleTime { get; }

        float ChargeSpeed { get; }
        float ChargeTime { get; }

        int CostForDefeat { get; }
    }

    [CreateAssetMenu(fileName = nameof(EnemyDataConfig),
                        menuName = "Configs/Enemy/" + nameof(EnemyDataConfig))]
    internal class EnemyDataConfig : ScriptableObject, IEnemyData
    {
        [field: SerializeField] public float MaxHealth { get; private set; }

        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float MoveThresh { get; private set; }
        
        [field: SerializeField] public float MinIdleTime { get; private set; } = 1f;
        [field: SerializeField] public float MaxIdleTime { get; private set; } = 2f;

        [field: SerializeField] public float ChargeSpeed { get; private set; } = 5f;

        [field: SerializeField] public float ChargeTime { get; private set; } = 2f;

        [field: SerializeField] public int CostForDefeat { get; private set; } = 10;

  
    }
}
