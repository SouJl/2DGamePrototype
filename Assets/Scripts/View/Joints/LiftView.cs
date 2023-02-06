using UnityEngine;

namespace PixelGame.View
{
    public class LiftView : LevelObjectView
    {
        [SerializeField] private SliderJoint2D _joint;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _stayTime = 2f;

        [Space(5)]
        [Header("Triggers")]

        [SerializeField] private LevelObjectView _maxLimitTrigger;
        [SerializeField] private LevelObjectView _minLimitTrigger;

        public SliderJoint2D Joint { get => _joint; }
        public float Speed { get => _speed; }
        public LevelObjectView MaxLimitTrigger { get => _maxLimitTrigger; }
        public LevelObjectView MinLimitTrigger { get => _minLimitTrigger; }
        public float StayTime { get => _stayTime; }

        public override void Awake()
        {
            base.Awake();
        }

        protected override void CollisionContact(Collider2D collision)
        {
            base.CollisionContact(collision);
            if (collision.TryGetComponent(out LevelObjectView collideObject))
            {
                OnLevelObjectContact?.Invoke(collideObject);
            }
        }
    }
}
