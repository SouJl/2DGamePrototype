using UnityEngine;

namespace PixelGame.View
{
    public class ElevatorView:LevelObjectView
    {
        [Header("Elevator Settings")]
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _waitTime = 2f;
        [SerializeField] private Vector2 _upperPos;
        [SerializeField] private Vector2 _lowerPos;

        public float Speed => _speed;
        public float WaitTime => _waitTime;
        public Vector2 UpperPos => _upperPos;
        public Vector2 LowerPos => _lowerPos;

        public override void Awake()
        {
            base.Awake();
        }

        private void OnDrawGizmos()
        {
            Vector2 upperPosLeft = new(_upperPos.x - 1, _upperPos.y);
            Vector2 upperPosRight = new(_upperPos.x + 1, _upperPos.y);
            Vector2 lowerPosLeft = new(_lowerPos.x - 1, _lowerPos.y);
            Vector2 lowerPosRight = new(_lowerPos.x + 1, _lowerPos.y);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(upperPosLeft, upperPosRight);
            Gizmos.DrawLine(lowerPosLeft, lowerPosRight);
        }
    }
}
