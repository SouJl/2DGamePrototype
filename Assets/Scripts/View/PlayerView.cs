using PixelGame.Components;
using PixelGame.Configs;
using UnityEngine;

namespace PixelGame.View
{
    public class PlayerView : LevelObjectView
    {
        [Header("Player Settings")]
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private PlayerData _playerData;

        [Space(10)]

        [Header("Animation Settings")]
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private AnimationConfig _animationConfig;

        [Header("Slope Settings")]
        [SerializeField] SlopeDataComponent _slopeData;


        [SerializeField] private GroundCheckComponent _groundCheck;
        [SerializeField] private Transform _wallCheck;
        [SerializeField] private Transform _ledgeCheck;

        public float MaxHealth { get => _maxHealth;}
        public PlayerData PlayerData { get => _playerData; }

        public int AnimationSpeed { get => _animationSpeed;}
        public AnimationConfig AnimationConfig { get => _animationConfig; }
        public SlopeDataComponent SlopeData { get => _slopeData; }
        public GroundCheckComponent GroundCheck { get => _groundCheck;  }
        public Transform LedgeCheck { get => _ledgeCheck;}
        public Transform WallCheck { get => _wallCheck; }

        public override void Awake()
        {
            base.Awake();
        }
    }
}
