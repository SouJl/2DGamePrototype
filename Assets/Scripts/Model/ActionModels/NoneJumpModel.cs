using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public sealed class NoneJumpModel : IJump
    {
        public float JumpForse { get; set; }
        public float JumpThershold { get; set; }
        public float FlyThershold { get; set; }
        public Vector2 Direction { get; set; }

        public void Jump(float velocity)
        {
            Debug.Log("[NoneJumpModel] - Unit can't jump!");
        }
    }
}
