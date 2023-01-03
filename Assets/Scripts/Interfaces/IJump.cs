using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface IJump
    {
        float JumpForse { get; set; }

        float JumpThershold { get; set; }

        float FlyThershold { get; set; }

        Vector2 Direction { get; set; }

        void Jump();
    }
}
