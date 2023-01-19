using UnityEngine;

namespace PixelGame.Model
{
    public class SimplePhysicsMove : AbstractMovementModel
    {
        public SimplePhysicsMove(Rigidbody2D rgdbody, float walkSpeed, float movingThresh) : base(rgdbody, walkSpeed, movingThresh)
        {
        }

        public override void Move(Vector2 vector) 
        {
            Rgdbody.velocity = vector * Speed * Time.fixedDeltaTime;
        }

        public override void Move(float inpitValue)
        {

            var xVelocity = inpitValue * Speed * Time.fixedDeltaTime;
            Rgdbody.velocity = new Vector2(xVelocity, Rgdbody.velocity.y);
        }
    }
}
