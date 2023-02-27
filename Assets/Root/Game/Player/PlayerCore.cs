using Root.PixelGame.Game.Core;
using UnityEngine;

namespace Assets.Root.Game.Player
{
    internal interface IPlayerCore
    {
        Vector2 CurrentVelocity { get; }

        Vector2 WorkVelocity { get; }

        void SetVelocityX(float velocity);
        void SeVelocityY(float velocity);
        void ChangePhysicsMaterial(PhysicsMaterial2D newMaterial);
    }

    internal class PlayerCore : IPlayerCore
    {
        private readonly Rigidbody2D rigidbody;

        private readonly IMove movement;

        public Vector2 CurrentVelocity { get; private set; }

        public Vector2 WorkVelocity { get; private set; }


        public PlayerCore(Rigidbody2D rigidbody, IMove movement)
        {
            this.rigidbody = rigidbody;
            this.movement = movement;
        }


        public void SetVelocityX(float velocity)
        {
            WorkVelocity.Set(velocity, CurrentVelocity.y);
            SetFinalVelocity();
        }

        public void SeVelocityY(float velocity)
        {
            WorkVelocity.Set(CurrentVelocity.x, velocity);
            SetFinalVelocity();
        }
        public void ChangePhysicsMaterial(PhysicsMaterial2D newMaterial) => 
            rigidbody.sharedMaterial = newMaterial;


        private void SetFinalVelocity() =>
            movement.Move(WorkVelocity.x, WorkVelocity.y);


    }
}
