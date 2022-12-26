using PixelGame.View;
using System;
using UnityEngine;

namespace PixelGame.Components
{
    public class LocatorComponent:MonoBehaviour
    {
        [SerializeField] private float _radius = 2f;
        [SerializeField] private LayerMask _layerMask;

        public Action<LevelObjectView> OnLacatorContact { get; set; }

        private bool _isHit;

        private void Awake()
        {
            _isHit = false;
        }

        private void Update()
        {
            if (_isHit) return;

            var hit = Physics2D.OverlapCircle(transform.position, _radius, _layerMask);
            if (hit) 
            {
                var collideObject = hit.gameObject.GetComponent<LevelObjectView>();
                OnLacatorContact?.Invoke(collideObject);
                _isHit = true;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}
