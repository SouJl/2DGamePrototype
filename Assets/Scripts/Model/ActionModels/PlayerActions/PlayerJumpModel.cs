using UnityEngine;

namespace PixelGame.Model
{
    public class PlayerJumpModel : AbstractJumpModel
    {

        public PlayerJumpModel(Rigidbody2D rigidbody, float jumpForce, float jumpThershold, float flyThershold) : base(rigidbody, jumpForce, jumpThershold, flyThershold) { }
        
        public override void Jump()
        {
            Rgdbody.AddForce(Vector2.up * JumpForse);
        }
    }
}
