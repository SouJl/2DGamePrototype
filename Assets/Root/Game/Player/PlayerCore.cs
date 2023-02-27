using Root.PixelGame.Game.Core;
using Root.PixelGame.Tool;
using UnityEngine;

namespace Root.PixelGame.Game
{
    internal interface IPlayerCore
    {
        ISlopeAnaliser SlopeAnaliser { get; }

        Vector2 CurrentVelocity { get; }

        Vector2 WorkVelocity { get; }

        int FacingDirection { get; }

        void CheckFlip(float xInpunt);
        void SetVelocityX(float velocity);
        void SetVelocityY(float velocity);
        void ChangePhysicsMaterial(PhysicsMaterial2D newMaterial);
    }

    internal class PlayerCore : IPlayerCore
    {
        private readonly Transform _transform;
        private readonly Rigidbody2D _rigidbody;
        private readonly Collider2D _collider;

        public ISlopeAnaliser SlopeAnaliser { get; private set; }

        public Vector2 CurrentVelocity { get; private set; }

        public Vector2 WorkVelocity { get; private set; }

        public int FacingDirection { get; private set; }

        public PlayerCore(Transform transform, Rigidbody2D rigidbody, Collider2D collider)
        {
            _transform = transform;
            _rigidbody = rigidbody;
            _collider = collider;

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
            WorkVelocity.Set(velocity, CurrentVelocity.y);
            SetFinalVelocity();
        }

        public void SetVelocityY(float velocity)
        {
            WorkVelocity.Set(CurrentVelocity.x, velocity);
            SetFinalVelocity();
        }
        public void ChangePhysicsMaterial(PhysicsMaterial2D newMaterial) =>
            _rigidbody.sharedMaterial = newMaterial;


        private void SetFinalVelocity() 
        {
            _rigidbody.velocity = WorkVelocity;
            CurrentVelocity = WorkVelocity;
        }


    }
}
