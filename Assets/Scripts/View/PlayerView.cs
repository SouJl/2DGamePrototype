using PixelGame.Configs;
using UnityEngine;

namespace PixelGame.View
{
    public class PlayerView : LevelObjectView
    {
        [Header("Player Settings")]
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private float _speed = 5f;
        
        [Space(10)]

        [Header("Animation Settings")]
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private AnimationConfig _animationConfig;

        public float MaxHealth { get => _maxHealth;}
        public float Speed { get => _speed;}
        public int AnimationSpeed { get => _animationSpeed;}
        public AnimationConfig AnimationConfig { get => _animationConfig; }

        public override void Awake()
        {
            base.Awake();
        }
    }
}
