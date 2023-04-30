using UnityEngine;

namespace PixelGame.Game.Machines
{
    internal interface IMachineView
    {
        Transform MachineTransfrom { get; }
        Rigidbody2D Rigidbody { get; }
        Collider2D Collider { get; }
    }

    [RequireComponent(typeof(Rigidbody2D))]
    internal abstract class MachineView : MonoBehaviour, IMachineView
    {
        [Header("Machine Settings")]
        [SerializeField] private Transform _machineTransform;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] protected Collider2D _collider;

        public Transform MachineTransfrom => _machineTransform;

        public Rigidbody2D Rigidbody => _rigidbody;

        public abstract Collider2D Collider { get; }

        protected virtual void OnValidate()
        {
            _machineTransform = gameObject.transform;
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        }

    }
}
