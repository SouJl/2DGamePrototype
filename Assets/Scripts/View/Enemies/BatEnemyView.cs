using PixelGame.Components;
using PixelGame.Configs;
using UnityEngine;

namespace PixelGame.View
{
    public class BatEnemyView : LevelObjectView
    {
        
        [Header("BatEnemy Settings")]
        [SerializeField] private float _maxHealth = 50f;
        [SerializeField] private LocatorComponent _locator;
        [SerializeField] private ProjectileWeaponView _weapon;

        [Space(10)]

        [Header("Action Settings")]
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _moveThresh = 0.01f;

        [Space(10)]

        [Header("Animation Settings")]
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private AnimationConfig _animationConfig;

        public float MaxHealth { get => _maxHealth; }
        public float Speed { get => _speed; }
        public float MoveThresh { get => _moveThresh; }
        public int AnimationSpeed { get => _animationSpeed; }
        public AnimationConfig AnimationConfig { get => _animationConfig; }
        public LocatorComponent Locator { get => _locator; }
        public ProjectileWeaponView Weapon { get => _weapon; }

        public override void Awake()
        {
            base.Awake();
        }
    }
}
