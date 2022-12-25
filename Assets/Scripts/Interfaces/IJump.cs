using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface IJump
    {
        float JumpForse { get; set; }

        void Jump();

        Vector2 GetVelocity();

        float GetPosition();
    }
}
