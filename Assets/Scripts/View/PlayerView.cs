using PixelGame.Components;
using PixelGame.Configs;
using UnityEngine;

namespace PixelGame.View
{
    public class PlayerView : LevelObjectView
    {
        [Header("Player Settings")]
        [SerializeField] private float _maxHealth = 100f;


        [Space(10)]

        [Header("Action Settings")]
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _moveThresh = 0.01f;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _jumpThreshold = 0.2f;
        [SerializeField] private float _flyThreshold = 1f;
        [SerializeField] private float _fallThreshold = 4f;
        [SerializeField] private float _wallSlideSpeed = 2f;

        [SerializeField] private int _rollFrames = 12;

        [Space(10)]

        [Header("Animation Settings")]
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private AnimationConfig _animationConfig;

        [Header("Slope Settings")]
        [SerializeField] SlopeDataComponent _slopeData;

        public float MaxHealth { get => _maxHealth;}
      
        public float Speed { get => _speed;}
        public float MoveThresh { get => _moveThresh;}
        public float JumpForce { get => _jumpForce;}        
        public float JumpThreshold { get => _jumpThreshold;}
        public float FlyThreshold { get => _flyThreshold;}
        public float FallThreshold { get => _fallThreshold; }
        public int RollFrames { get => _rollFrames; }
        public float WallSlideSpeed { get => _wallSlideSpeed;}


        public int AnimationSpeed { get => _animationSpeed;}
        public AnimationConfig AnimationConfig { get => _animationConfig; }
        public SlopeDataComponent SlopeData { get => _slopeData; }

        public override void Awake()
        {
            base.Awake();
        }
    }
}
