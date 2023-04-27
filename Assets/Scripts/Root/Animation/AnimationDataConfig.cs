using UnityEngine;
using System.Collections.Generic;
using System;

namespace Root.PixelGame.Animation
{
    internal interface IAnimationData
    {
        float AnimationSpeed { get; }
        IReadOnlyCollection<IAnimation> AnimationConfigs { get; }
    }

    [CreateAssetMenu(fileName = nameof(AnimationDataConfig),
        menuName = "Configs/Animation/" + nameof(AnimationDataConfig))]
    internal class AnimationDataConfig : ScriptableObject, IAnimationData
    {
        [SerializeField] private float _animationSpeed = 10f;
        [SerializeField] private SpriteAnimation[] _spriteAnimationConfigs;

        public float AnimationSpeed => _animationSpeed;
        public IReadOnlyCollection<IAnimation> AnimationConfigs => _spriteAnimationConfigs;

       
    }
}
