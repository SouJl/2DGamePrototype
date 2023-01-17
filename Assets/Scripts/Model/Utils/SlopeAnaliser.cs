using UnityEngine;

namespace PixelGame.Model.Utils
{
    public class SlopeAnaliser
    {
        private Rigidbody2D _rigidbody;
        private Vector2 _colliderSize;
        private float _slopeCheckDistance;
        private float _maxSlopeAngle;
        
        private LayerMask _layerMask;
        
        private bool _isOnSlope;
        private bool _canWalkOnSlope;
        private float _slopeDownAngle;
        private float _slopeSideAngle;
        private float _lastSlopeAngle;

        private Vector2 _slopeNormalPerp;

        public bool IsOnSlope { get => _isOnSlope; }
        public bool CanWalkOnSlope { get => _canWalkOnSlope; }
        public bool IsSlopeAngle { get => _slopeDownAngle <= _maxSlopeAngle; }
        public Vector2 SlopeNormalPerp { get => _slopeNormalPerp; }

        public SlopeAnaliser(Rigidbody2D rigidbody, Collider2D collider, float slopeCheckDistance, float maxSlopeAngle, LayerMask layerMask) 
        {
            _rigidbody = rigidbody;
            _colliderSize = (collider as CapsuleCollider2D).size;
            _slopeCheckDistance = slopeCheckDistance;
            _maxSlopeAngle = maxSlopeAngle;
            _layerMask = layerMask;
        }

        
        public void SlopeCheck()
        {
            Vector2 checkPos = _rigidbody.position - new Vector2(0.0f, _colliderSize.y / 2);

            SlopeCheckHorizontal(checkPos);
            SlopeCheckVertical(checkPos);
        }

        private void SlopeCheckHorizontal(Vector2 checkPos)
        {
            RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPos, _rigidbody.transform.right, _slopeCheckDistance, _layerMask);
            RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPos, -_rigidbody.transform.right, _slopeCheckDistance, _layerMask);

            if (slopeHitFront)
            {
                _isOnSlope = true;

                _slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);

            }
            else if (slopeHitBack)
            {
                _isOnSlope = true;

                _slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
            }
            else
            {
                _slopeSideAngle = 0.0f;
                _isOnSlope = false;
            }
        }

        private void SlopeCheckVertical(Vector2 checkPos)
        {
            RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, _slopeCheckDistance, _layerMask);

            if (hit)
            {

                _slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;

                _slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

                if (_slopeDownAngle != _lastSlopeAngle)
                {
                    _isOnSlope = true;
                }

                _lastSlopeAngle = _slopeDownAngle;

                Debug.DrawRay(hit.point, _slopeNormalPerp, Color.blue);
                Debug.DrawRay(hit.point, hit.normal, Color.green);

            }

            if (_slopeDownAngle > _maxSlopeAngle || _slopeSideAngle > _maxSlopeAngle)
            {
                _canWalkOnSlope = false;
            }
            else
            {
                _canWalkOnSlope = true;
            }
        }
    }
}
