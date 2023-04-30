using UnityEngine;

namespace PixelGame.Game.Machines
{
    internal interface IElevatorView :IMachineView
    {
        Vector2 UpperPos { get; }
        Vector2 LowerPos { get; }
    }

    [RequireComponent(typeof(BoxCollider2D))]
    internal class ElevatorView : MachineView, IElevatorView
    {
        [Header("Elevator Settings")]
        [SerializeField] private Vector2 _upperPos;
        [SerializeField] private Vector2 _lowerPos;

        public Vector2 UpperPos => _upperPos;
        public Vector2 LowerPos => _lowerPos;

        public override Collider2D Collider => _collider;

        protected override  void OnValidate()
        {
            base.OnValidate();
            _collider = gameObject.GetComponent<BoxCollider2D>();
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
