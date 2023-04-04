using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal interface IRotate
    {
        int FacingDirection { get; }
        void Rotate();
    }
}
