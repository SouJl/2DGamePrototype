using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface IMove
    {
        float Speed { get; set; }
        float MovingThresh { get; set; }
        void Move(float inpitValue);
        void Move(Vector2 vector);
    }
}
