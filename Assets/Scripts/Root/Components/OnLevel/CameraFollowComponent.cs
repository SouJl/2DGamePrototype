using UnityEngine;

namespace Root.PixelGame.Components
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    internal class CameraFollowComponent : MonoBehaviour
    {
        [SerializeField] private Transform _followTarget;
        [SerializeField] private float _maxX = 100f;
        [SerializeField] private float _minX = -10f;
        [SerializeField] private float _maxY = 10;
        [SerializeField] private float _minY = -10;
        [SerializeField] private float _xOffset = 0f;
        [SerializeField] private float _yOffset = 0f;
        [SerializeField] private float _smoothTime = 0.25f;

        private Vector3 _velocity = Vector3.zero;

        private void FixedUpdate()
        {
            if (!_followTarget) return;

            var clampPosX = Mathf.Clamp(_followTarget.position.x + _xOffset, _minX, _maxX);
            var clampPosY = Mathf.Clamp(_followTarget.position.y + _yOffset, _minY, _maxY);
            var targetPos = new Vector3(clampPosX, clampPosY, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, _smoothTime);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            ChangeeCamPosToTarget();
        }

        private void ChangeeCamPosToTarget()
        {
            if (Application.isEditor && !Application.isPlaying)
            {
                if (_followTarget)
                {
                    var _targetPos = new Vector3(_followTarget.position.x, _followTarget.position.y, transform.position.z);
                    transform.position = _targetPos;
                }
            }
        }
#endif
    }
}
