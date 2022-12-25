using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public sealed class NoneJumpModel : IJump
    {
        public float JumpForse { get; set; }
        public float JumpThershold { get; set; }

        public void Jump()
        {
            Debug.Log("[NoneJumpModel] - Unit can't move!");
        }

        public Vector2 GetVelocity() => Vector2.zero;

        public float GetPosition() => 0;
    }
}
