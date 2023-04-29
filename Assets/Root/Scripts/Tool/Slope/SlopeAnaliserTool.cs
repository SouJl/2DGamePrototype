using UnityEngine;

namespace PixelGame.Tool
{
    internal interface ISlopeAnaliser 
    {
        public bool IsOnSlope { get; }
        public bool CanWalkOnSlope { get; }
        public bool IsSlopeAngle { get; }
        public Vector2 SlopeNormalPerp { get; }
        public void SlopeCheck();
    }


    internal class SlopeAnaliserTool : ISlopeAnaliser
    {
        private readonly string configPath = @"Tool/Slope/SlopeAnaliseConfig";

        private readonly Rigidbody2D _rigidbody;
        private readonly Vector2 _colliderSize;
        private readonly ISlopeAnaliseConfig _config;

        private float _slopeDownAngle;
        private float _slopeSideAngle;
        private float _lastSlopeAngle;

        public bool IsOnSlope { get; private set; }
        public bool CanWalkOnSlope { get; private set; }
        public bool IsSlopeAngle { get => _slopeDownAngle <= _config.MaxAngle; }
        public Vector2 SlopeNormalPerp { get; private set; }


        public SlopeAnaliserTool(Rigidbody2D rigidbody, Collider2D collider)
        {
            _rigidbody = rigidbody;
            _colliderSize = (collider as CapsuleCollider2D).size;
            _config = LoadConfig(configPath);
        }

        public void SlopeCheck()
        {
            Vector2 checkPos = _rigidbody.position - new Vector2(0.0f, _colliderSize.y / 2);

            SlopeCheckHorizontal(checkPos);
            SlopeCheckVertical(checkPos);
        }

        private ISlopeAnaliseConfig LoadConfig(string path) => 
            ResourceLoader.LoadObject<SlopeAnaliseConfig>(path);

        private void SlopeCheckHorizontal(Vector2 checkPos)
        {
            RaycastHit2D slopeHitFront = GetRaycastHit(checkPos, _rigidbody.transform.right, _config.CheckDistance, _config.Mask);
            RaycastHit2D slopeHitBack = GetRaycastHit(checkPos, -_rigidbody.transform.right, _config.CheckDistance, _config.Mask);

            if (slopeHitFront)
            {
                IsOnSlope = true;

                _slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);

            }
            else if (slopeHitBack)
            {
                IsOnSlope = true;

                _slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
            }
            else
            {
                _slopeSideAngle = 0.0f;
                IsOnSlope = false;
            }
        }

        private void SlopeCheckVertical(Vector2 checkPos)
        {
            RaycastHit2D hit = GetRaycastHit(checkPos, Vector2.down, _config.CheckDistance, _config.Mask);

            if (hit)
            {

                SlopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;

                _slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

                if (_slopeDownAngle != _lastSlopeAngle)
                {
                    IsOnSlope = true;
                }

                _lastSlopeAngle = _slopeDownAngle;

                Debug.DrawRay(hit.point, SlopeNormalPerp, Color.blue);
                Debug.DrawRay(hit.point, hit.normal, Color.green);

            }

            if (_slopeDownAngle > _config.MaxAngle || _slopeSideAngle > _config.MaxAngle)
            {
                CanWalkOnSlope = false;
            }
            else
            {
                CanWalkOnSlope = true;
            }
        }

        private RaycastHit2D GetRaycastHit(Vector2 origin, 
            Vector2 direction, 
            float distance, 
            LayerMask layerMask) => Physics2D.Raycast(origin, direction, distance, layerMask);

    }
}
