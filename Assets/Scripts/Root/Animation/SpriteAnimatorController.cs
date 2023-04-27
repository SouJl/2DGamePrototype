using System;
using System.Linq;
using UnityEngine;

namespace Root.PixelGame.Animation
{
    internal interface IAnimatorController : IDisposable
    {
        bool IsAnimationEnd { get; }
        void StartAnimation(AnimationType state);
        void StopAnimation();
        void Update();
    }

    internal class SpriteAnimatorController : IAnimatorController
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly IAnimationData _animationData;

        private Animation _animation;

        public bool IsAnimationEnd { get; private set; }

        public SpriteAnimatorController(SpriteRenderer spriteRenderer, IAnimationData animationData)
        {
            _spriteRenderer
                = spriteRenderer ?? throw new ArgumentNullException(nameof(spriteRenderer));

            _animationData
                = animationData ?? throw new ArgumentNullException(nameof(animationData));
            
            _animation = new Animation();
        }

        public void StartAnimation(AnimationType state)
        {
            float animationSpeed = _animationData.AnimationSpeed;
            IAnimation animationConfig
                = _animationData.AnimationConfigs.ToList().Find(anim => anim.State == state);

            InitAnimation(animationSpeed, animationConfig);

        }

        public void StopAnimation()
        {
            _animation.Sleeps = true;
        }


        public void Update()
        {
            if (_animation.Sprites == null) return;

            _animation.Update();
            _spriteRenderer.sprite = _animation.Sprites[(int)_animation.Counter];
            IsAnimationEnd = _animation.Sleeps;
        }

        private void InitAnimation(float animationSpeed, IAnimation animationConfig)
        {
            _animation.Speed = animationSpeed;
            _animation.State = animationConfig.State;
            _animation.Sprites = animationConfig.Sprites.ToList();
            _animation.Loop = animationConfig.Loop;
            _animation.Counter = 0;
            _animation.Sleeps = false;
        }

        #region IDisposable
        public void Dispose()
        {
            _animation = default;
        }

        #endregion
    }
}
