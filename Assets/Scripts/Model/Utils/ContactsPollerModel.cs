using PixelGame.Components;
using PixelGame.Configs;
using UnityEngine;

namespace PixelGame.Model
{
    public class ContactsPollerModel
    {
        public Vector2 GroundVelocity { get; private set; }

        private Transform _groundCheckPos;
        private float _groundCheckRadius;
        private LayerMask _groundLayerMask;
        private Transform _wallCheck;
        private Transform _ledgeCheck;

        private PlayerData _playerData;

        public ContactsPollerModel(PlayerData  playerData, GroundCheckComponent groundCheck, Transform wallCheck, Transform ledgeCheck) 
        {
            _playerData = playerData;
            _groundCheckPos = groundCheck.GroundCheck;
            _groundCheckRadius = groundCheck.Radius;
            _groundLayerMask = groundCheck.LayerMask;
            _wallCheck = wallCheck;
            _ledgeCheck = ledgeCheck;
        }

        public bool CheckGround()
        {
            var hit = Physics2D.OverlapCircle(_groundCheckPos.position, _groundCheckRadius, _groundLayerMask);

            Color rayColor;
            if (hit != null)
            {
                rayColor = Color.blue;
                GroundVelocity = hit.attachedRigidbody.velocity;
            }
            else
            {
                rayColor = Color.red;
                GroundVelocity = Vector2.zero;
            }

            Debug.DrawRay(_groundCheckPos.position, Vector2.down * 0.5f, rayColor);

            return hit != null;
        }

        public bool CheckWallFront(int facingDirection) 
        {
            return Physics2D.Raycast(_wallCheck.position, Vector2.right * facingDirection, _playerData.wallCheckDistance, _groundLayerMask); 
        }
        public bool CheckWallBack(int facingDirection)
        {
            return Physics2D.Raycast(_wallCheck.position, Vector2.left * facingDirection, _playerData.wallCheckDistance, _groundLayerMask);
        }

        public bool CheckLedgeTouch(int facingDirection) 
        {
            var rayColor = Color.green;
            Debug.DrawRay(_ledgeCheck.position, Vector2.right * facingDirection * _playerData.wallCheckDistance, rayColor);
            return Physics2D.Raycast(_ledgeCheck.position, Vector2.right * facingDirection, _playerData.wallCheckDistance, _groundLayerMask);
        }


        public Vector2 DetermineCornerPos(int facingDirection)
        {
            Vector2 result = Vector2.zero;
            RaycastHit2D xHit = Physics2D.Raycast(_wallCheck.position, Vector2.right * facingDirection, _playerData.wallCheckDistance, _groundLayerMask);
            float xDist = xHit.distance;
            result.Set((xDist + 0.015f) * facingDirection, 0f);
            RaycastHit2D yHit = Physics2D.Raycast(_ledgeCheck.position + (Vector3)result, Vector2.down, _ledgeCheck.position.y - _wallCheck.position.y, _groundLayerMask);
            float yDist = yHit.distance;
            result.Set(_wallCheck.position.x + (xDist * facingDirection), _ledgeCheck.position.y - yDist);
            return result;
        }

        public bool CheckCornerSpace(Vector2 _cornerPos, int facingDirection)
        {
            return Physics2D.Raycast(_cornerPos + (Vector2.up * 0.015f) + (Vector2.right * facingDirection * 0.015f), Vector2.up, _playerData.standColliderHeight, _groundLayerMask);
        }
    }
}
