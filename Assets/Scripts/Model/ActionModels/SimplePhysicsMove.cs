using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public class SimplePhysicsMove : AbstractMovementModel
    {
        public SimplePhysicsMove(IUnit unit) : base(unit)
        {
        }

        public override void Move(Vector2 resultVelocity)
        {
            Unit.UnitComponents.RgdBody.velocity = resultVelocity;
            Unit.CurrentVelocity = resultVelocity;
        }
    }
}
