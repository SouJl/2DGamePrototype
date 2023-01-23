using UnityEngine;

namespace PixelGame.Components
{
    public class GroundCheckComponent:MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _radius = 1f;
        [SerializeField] private LayerMask _layerMask;

        public Transform GroundCheck { get => _groundCheck; set => _groundCheck = value; }
        public LayerMask LayerMask { get => _layerMask;}
        public float Radius { get => _radius; }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_groundCheck.position, _radius);
        }
    }
}
