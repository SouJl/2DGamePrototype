using UnityEngine;

namespace PixelGame.Model
{
    public class PlayerJumpModel : AbstractJumpModel
    {
        public PlayerJumpModel(Rigidbody2D rigidbody, float jumpForce) : base(rigidbody, jumpForce)
        {
        }

        public override void Jump()
        {
            Rgdbody.AddForce(Vector2.up * JumpForse);
        }
    }
}
