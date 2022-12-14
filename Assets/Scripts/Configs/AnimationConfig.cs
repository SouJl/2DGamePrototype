using PixelGame.Enumerators;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Configs
{
    [CreateAssetMenu(fileName = "SpriteAnimationCfg", menuName = "Configs/Animation")]
    public class AnimationConfig : ScriptableObject
    {
        [Serializable]
        public class SpriteSequence
        {
            public AnimaState State;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSequence> SpriteSequences = new List<SpriteSequence>();
    }
}

