using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface IMove
    {
        float Speed { get; set; }
        float MovingThresh { get; set; }
        void Move(Vector2 input);
    }
}
