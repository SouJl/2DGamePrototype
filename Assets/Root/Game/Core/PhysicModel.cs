using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal interface IPhysicModel
    {
        Rigidbody2D Rigidbody { get; }
        
        Vector2 CurrentVelocity { get; }

        void SetVelocityX(float velocity);
        void SetVelocityY(float velocity);
        void ChangePhysicsMaterial(PhysicsMaterial2D newMaterial);

        void Update();
    }

    internal class PhysicModel : IPhysicModel
    {
        public Rigidbody2D Rigidbody { get; private set; }

        public Vector2 CurrentVelocity { get; private set; }

        private Vector2 _workVelocity;

  
        public PhysicModel(Rigidbody2D rigidbody)
        {
            Rigidbody = rigidbody;
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
            Rigidbody.sharedMaterial = newMaterial;


        private void SetFinalVelocity()
        {
            Rigidbody.velocity = _workVelocity;
            CurrentVelocity = _workVelocity;
        }

        public void Update()
        {
            CurrentVelocity = Rigidbody.velocity;
        }
    }
}
