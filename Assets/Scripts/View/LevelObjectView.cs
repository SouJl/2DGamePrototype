using UnityEngine;

namespace PixelGame.View 
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class LevelObjectView : MonoBehaviour
    {
        [Header("Object base settings")]
        [SerializeField] private Transform _transform;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;

        public Transform Transform { get => _transform;}
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer;}
        public Collider2D Collider { get => _collider;}
        public Rigidbody2D Rigidbody { get => _rigidbody; }

        public virtual void Awake()
        {
            _transform = GetComponent<Transform>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            if(TryGetComponent(out Collider2D collider)) 
            {
                _collider = collider;
            }
            if (TryGetComponent(out Rigidbody2D rigidbody))
            {
                _rigidbody = rigidbody;
            }
        }
    }
}

