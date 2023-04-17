using Root.PixelGame.Components.AI;
using UnityEngine;

namespace Root.PixelGame.Components.Core
{
    internal interface IEnemyCoreComponent : ICoreComponent
    {
        IAIViewComponent AIViewComponent { get; }
    }

    [RequireComponent(typeof(Rigidbody2D))]
    internal abstract class EnemyCoreComponent : MonoBehaviour, IEnemyCoreComponent
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody2D _rigidbody;

        public Transform Transform => _transform;
        public Rigidbody2D Rigidbody => _rigidbody;

        public abstract IAIViewComponent AIViewComponent { get; }

        protected virtual void Awake()
        {
            _transform = gameObject.transform;
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        }
    }
}
