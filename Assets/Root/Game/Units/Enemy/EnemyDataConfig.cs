using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyData
    {
        float MaxHealth { get; }
        float Speed { get; }
        float MoveThresh { get; }
        int CostForDefeat { get; }
    }

    [CreateAssetMenu(fileName = nameof(EnemyDataConfig),
                        menuName = "Configs/Enemy/" + nameof(EnemyDataConfig))]
    internal class EnemyDataConfig : ScriptableObject, IEnemyData
    {
        [field: SerializeField] public float MaxHealth { get; private set; }

        [field: SerializeField] public float Speed { get; private set; }

        [field: SerializeField] public float MoveThresh { get; private set; }

        [field: SerializeField] public int CostForDefeat { get; private set; } = 10;
    }
}
