using UnityEngine;

namespace Root.PixelGame.Components.Core
{
    internal interface ICoreComponent 
    {
        Transform Transform { get; }
        Rigidbody2D Rigidbody { get; }
        Collider2D Collider { get; }
    }

    [RequireComponent(typeof(Rigidbody2D))]
    internal class CoreComponent : MonoBehaviour, ICoreComponent
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _collider;

        public Transform Transform => _transform;
        public Rigidbody2D Rigidbody => _rigidbody;
        public Collider2D Collider => _collider;

        protected virtual void Awake()
        {
            _transform = gameObject.transform;
            _rigidbody ??= gameObject.GetComponent<Rigidbody2D>();
        }
    }
}
