using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public sealed class NoneMoveModel : IMove
    {
        public float Speed { get; set; }
        public float MovingThresh { get; set; }

        public void Move(float inpitValue)
        {
            Debug.Log("[NoneMoveModel] - Unit can't move!");
        }
    }
}
