using UnityEngine;

namespace PixelGame.Components
{
    public class GroundCheckComponent:MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _width = 1f;
        [SerializeField] private float _height = 0.3f;

        public Transform GroundCheck { get => _groundCheck; set => _groundCheck = value; }
        public float Width { get => _width; set => _width = value; }
        public float Height { get => _height; set => _height = value; }

        private void OnDrawGizmos()
        {
            Gizmos.DrawCube(_groundCheck.position, new Vector3(_width, _height, 0));
        }
    }
}
