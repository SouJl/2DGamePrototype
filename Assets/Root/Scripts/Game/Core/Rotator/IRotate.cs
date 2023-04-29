using UnityEngine;

namespace PixelGame.Game.Core
{
    internal interface IRotate
    {
        int FacingDirection { get; }
        void Rotate();
    }
}
