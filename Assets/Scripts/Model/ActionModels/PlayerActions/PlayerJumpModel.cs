using UnityEngine;

namespace PixelGame.Model
{
    public class PlayerJumpModel : AbstractJumpModel
    {

        public PlayerJumpModel(Rigidbody2D rigidbody, float jumpForce, float jumpThershold) : base(rigidbody, jumpForce, jumpThershold) { }
        
        public override void Jump()
        {
            Rgdbody.AddForce(Vector2.up * JumpForse);
        }
    }
}
