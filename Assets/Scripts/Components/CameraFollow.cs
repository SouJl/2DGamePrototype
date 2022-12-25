using PixelGame.View;
using UnityEngine;

namespace PixelGame.Components
{
    [RequireComponent(typeof(Camera))]
    public class CameraFollow:MonoBehaviour
    {
        [SerializeField] private LevelObjectView _followTarget;
        [SerializeField] private float _xOffset = 0f;
        [SerializeField] private float _smoothTime = 0.25f;

        private Vector3 _velocity = Vector3.zero;

        private void FixedUpdate()
        {
            if (!_followTarget) return;

            var targetPos = new Vector3(_followTarget.transform.position.x + _xOffset, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, _smoothTime);
        }
    }
}
