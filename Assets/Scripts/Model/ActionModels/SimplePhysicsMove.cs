using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public class SimplePhysicsMove : AbstractMovementModel
    {
        public SimplePhysicsMove(IUnit unit, float walkSpeed, float movingThresh) : base(unit, walkSpeed, movingThresh)
        {
        }

        public override void Move(float velocity)
        {
            workVelocity.Set(velocity * Speed, Unit.CurrentVelocity.y);
            Unit.UnitComponents.RgdBody.velocity = workVelocity;
            Unit.CurrentVelocity = workVelocity;
        }
    }
}
