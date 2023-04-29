using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Animation
{
    internal interface IAnimation
    {
        bool Loop { get; }
        AnimationType State { get; }
        IReadOnlyCollection<Sprite> Sprites { get; }
    }

    [Serializable]
    internal class SpriteAnimation : IAnimation
    {
        [field: SerializeField] public bool Loop { get; private set; }
        [field: SerializeField] public AnimationType State { get; private set; }

        public Sprite[] _sprites;
        public IReadOnlyCollection<Sprite> Sprites => _sprites;


    }
}
