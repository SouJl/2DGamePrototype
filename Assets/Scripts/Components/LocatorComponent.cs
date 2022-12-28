using PixelGame.View;
using System;
using UnityEngine;

namespace PixelGame.Components
{
    public class LocatorComponent:MonoBehaviour
    {
        [SerializeField] private float _radius = 2f;
        [SerializeField] private float _updateDelay = 3f;
        [SerializeField] private LayerMask _layerMask;

        public Action<LevelObjectView> OnLacatorContact { get; set; }

        private void FixedUpdate()
        {
            var hit = Physics2D.OverlapCircle(transform.position, _radius, _layerMask);
            if (hit)
            {
                var collideObject = hit.gameObject.GetComponent<LevelObjectView>();
                OnLacatorContact?.Invoke(collideObject);

            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}
