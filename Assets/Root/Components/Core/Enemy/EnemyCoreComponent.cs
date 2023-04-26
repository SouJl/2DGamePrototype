using Root.PixelGame.Components.AI;
using UnityEngine;

namespace Root.PixelGame.Components.Core
{
    internal interface IEnemyCoreComponent : ICoreComponent
    {
        IAIComponent AIViewComponent { get; }
    }

    [RequireComponent(typeof(Rigidbody2D))]
    internal abstract class EnemyCoreComponent : MonoBehaviour, IEnemyCoreComponent
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _collider;
        public Transform Transform => _transform;
        public Rigidbody2D Rigidbody => _rigidbody;
        public Collider2D Collider => _collider;

        public abstract IAIComponent AIViewComponent { get; }

        protected virtual void Awake()
        {
            _transform ??= gameObject.transform;
            _rigidbody ??= gameObject.GetComponent<Rigidbody2D>();
        }

        private void OnValidate()
        {
            _transform = gameObject.transform;
            _rigidbody ??= GetComponent<Rigidbody2D>();
        }
    }
}
