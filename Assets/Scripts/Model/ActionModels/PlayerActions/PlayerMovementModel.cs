using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public class PlayerMovementModel : AbstractMovementModel
    {
        public PlayerMovementModel(Rigidbody2D rgdbody, float speed, float movingThresh) : base(rgdbody, speed, movingThresh) { }

        public override void Move(float inpitValue)
        {
            var xVelocity = inpitValue * Speed * Time.fixedDeltaTime;
            Rgdbody.velocity = new Vector2(xVelocity, Rgdbody.velocity.y);
        }

        public void Move(Vector2 input) 
        {
            Rgdbody.velocity = input * Speed * Time.fixedDeltaTime;
        }
    }
}
