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

        private void FixedUpdate()
        {
            var hit = Physics2D.OverlapCircle(transform.position, _radius, _layerMask);
            if (hit)
            {
                bool isEmptyTrail = true;
                var onTrailHits = Physics2D.LinecastAll(transform.position, hit.transform.position);
                foreach (var onTrailHit in onTrailHits) 
                {
                    if (onTrailHit.collider.tag == "Ground") isEmptyTrail = false;
                }
                if (isEmptyTrail) 
                {
                    var collideObject = hit.gameObject.GetComponent<LevelObjectView>();
                    OnLacatorContact?.Invoke(collideObject);
                }            
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}
