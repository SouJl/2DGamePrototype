using UnityEngine;

namespace PixelGame.View
{
    [RequireComponent(typeof(SliderJoint2D))]
    public class LiftView:LevelObjectView
    {
        [SerializeField] private SliderJoint2D _joint;
        [SerializeField] private float _speed = 2f;

        public SliderJoint2D Joint { get => _joint;}
        public float Speed { get => _speed; }

        public override void Awake()
        {
            base.Awake();
            _joint = GetComponent<SliderJoint2D>();
        }
    }
}
