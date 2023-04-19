using UnityEngine;

namespace Root.PixelGame.Components.Core
{
    internal interface ICoreComponent 
    {
        Transform Transform { get; }
        Rigidbody2D Rigidbody { get; }
    }

    [RequireComponent(typeof(Rigidbody2D))]
    internal class CoreComponent : MonoBehaviour, ICoreComponent
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody2D _rigidbody;

        public Transform Transform => _transform;
        public Rigidbody2D Rigidbody => _rigidbody;

        protected virtual void Awake()
        {
            _transform = gameObject.transform;
            _rigidbody ??= gameObject.GetComponent<Rigidbody2D>();
        }
    }
}
