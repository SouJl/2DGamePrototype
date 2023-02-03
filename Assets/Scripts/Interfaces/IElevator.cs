using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface IElevator
    {
        bool IsWork { get; }

        Vector2 Direction { get;}

        void Start();
        
        void Stop();

        void UpdatePosition(float time);
    }
}
