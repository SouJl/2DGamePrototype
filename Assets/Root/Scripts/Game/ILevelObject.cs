using UnityEngine;

namespace PixelGame.Game
{
    internal interface ILevelObject
    {
        Transform LObjTransform { get; }
        Rigidbody2D LObjRigidbody { get; }
    }
}
