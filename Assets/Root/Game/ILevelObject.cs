using UnityEngine;

namespace Root.PixelGame.Game
{
    internal interface ILevelObject
    {
        Transform LObjTransform { get; }
        Rigidbody2D LObjRigidbody { get; }
    }
}
