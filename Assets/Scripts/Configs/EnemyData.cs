using UnityEngine;

namespace PixelGame.Configs
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Configs/UnitConfigs/Enemy")]
    public class EnemyData:ScriptableObject
    {
        [Header("Base Settings")]
        public float maxHealth = 100f;

        [Header("Move settings")]
        public float speed = 10f;
        public float moveThresh = 0.01f;

  
        [Header("Animation Settings")]
        public int animationSpeed = 10;
        public AnimationConfig animationConfig;
    }
}
