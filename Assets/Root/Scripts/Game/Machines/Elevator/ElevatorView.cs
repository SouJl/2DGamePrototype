using UnityEngine;

namespace PixelGame.Game.Machines
{
    internal interface IElevatorView
    {

    }

    internal class ElevatorView :MonoBehaviour, IElevatorView
    {
        [Header("Elevator Settings")]
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _waitTime = 2f;
        [SerializeField] private Vector2 _upperPos;
        [SerializeField] private Vector2 _lowerPos;
        [SerializeField] private Rigidbody2D _rigid;

        public float Speed => _speed;
        public float WaitTime => _waitTime;
        public Vector2 UpperPos => _upperPos;
        public Vector2 LowerPos => _lowerPos;

        public Rigidbody2D Rigidbody => _rigid;

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
