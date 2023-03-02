using Root.PixelGame.Game.Core;
using Root.PixelGame.Tool;
using UnityEngine;

namespace Root.PixelGame.Game
{
    internal interface IPlayerCore
    {
        ISlopeAnaliser SlopeAnaliser { get; }

        Vector2 CurrentVelocity { get; }

        int FacingDirection { get; }

        void CheckFlip(float xInpunt);
        void SetVelocityX(float velocity);
        void SetVelocityY(float velocity);
        void ChangePhysicsMaterial(PhysicsMaterial2D newMaterial);

        bool CheckGround();
    }

    internal class PlayerCore : IPlayerCore
    {
        private readonly Transform _transform;
        private readonly Rigidbody2D _rigidbody;
        private readonly Collider2D _collider;

        private readonly Transform _groundCheck;
        private readonly LayerMask _groundLayerMask;

        public ISlopeAnaliser SlopeAnaliser { get; private set; }

        public Vector2 CurrentVelocity { get; private set; }

        public int FacingDirection { get; private set; }

        private Vector2 _workVelocity;

        public PlayerCore(Transform transform, Rigidbody2D rigidbody, Collider2D collider, Transform groundCheck, LayerMask groundLayerMask)
        {
            _transform = transform;
            _rigidbody = rigidbody;
            _collider = collider;
            _groundCheck = groundCheck;
            _groundLayerMask = groundLayerMask;

            SlopeAnaliser = new SlopeAnaliserTool(_rigidbody, _collider);
            FacingDirection = 1;
        }

        public void CheckFlip(float xInpunt)
        {
            if (xInpunt != 0 && (xInpunt * FacingDirection) < 0)
            {
                FacingDirection *= -1;
                _transform.Rotate(0.0f, 180.0f, 0.0f);
            }
        }

        public void SetVelocityX(float velocity)
        {
            _workVelocity.Set(velocity, CurrentVelocity.y);
            SetFinalVelocity();
        }

        public void SetVelocityY(float velocity)
        {
            _workVelocity.Set(CurrentVelocity.x, velocity);
            SetFinalVelocity();
        }
        public void ChangePhysicsMaterial(PhysicsMaterial2D newMaterial) =>
            _rigidbody.sharedMaterial = newMaterial;


        private void SetFinalVelocity() 
        {
            _rigidbody.velocity = _workVelocity;
            CurrentVelocity = _workVelocity;
        }

        public bool CheckGround()
        {
            var hit = Physics2D.OverlapCircle(_groundCheck.position, 0.5f, _groundLayerMask);

            Color rayColor;
            if (hit != null)
            {
                rayColor = Color.blue;
            }
            else
            {
                rayColor = Color.red;
            }

            Debug.DrawRay(_groundCheck.position, Vector2.down * 0.5f, rayColor);

            return hit != null;
        }


    }
}
