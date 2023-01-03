using System;
using UnityEngine;

namespace PixelGame.View 
{
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


        public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        public virtual void Awake()
        {
            _transform = GetComponent<Transform>();
            if (TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                _spriteRenderer = spriteRenderer;
            }
            if(TryGetComponent(out Collider2D collider)) 
            {
                _collider = collider;
            }
            if (TryGetComponent(out Rigidbody2D rigidbody))
            {
                _rigidbody = rigidbody;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var collideObject = collision.gameObject.GetComponent<LevelObjectView>();
            OnLevelObjectContact?.Invoke(collideObject);
        }
    }
}

