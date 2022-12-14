using PixelGame.Configs;
using PixelGame.Enumerators;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Controllers 
{
    public sealed class Animation
    {
        public AnimaState State;
        public List<Sprite> Sprites;
        public bool Loop = false;
        public float Speed = 10;
        public float Counter = 0;
        public bool Sleeps;

        public void Update()
        {
            if (Sleeps) return;
            Counter += Time.deltaTime * Speed;
            if (Loop)
            {
                while (Counter > Sprites.Count)
                {
                    Counter -= Sprites.Count;
                }
            }
            else if (Counter > Sprites.Count)
            {
                Counter = Sprites.Count;
                Sleeps = true;
            }
        }
    }

    public class SpriteAnimatorController : IDisposable
    {
        private AnimationConfig _config;
        private Dictionary<SpriteRenderer, Animation> _activeAnimations = new Dictionary<SpriteRenderer, Animation>();


        public SpriteAnimatorController(AnimationConfig config) 
        {
            _config = config;
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, AnimaState state, bool loop, float speed)
        {
            if (_activeAnimations.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = speed;
                animation.Sleeps = false;
                if (animation.State != state)
                {
                    animation.State = state;
                    animation.Sprites = _config.SpriteSequences.Find(sequence => sequence.State == state).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimations.Add(spriteRenderer, new Animation()
                {
                    State = state,
                    Sprites = _config.SpriteSequences.Find(sequence => sequence.State == state).Sprites,
                    Loop = loop,
                    Speed = speed
                });
            }
        }


        public void StopAnimation(SpriteRenderer sprite)
        {
            if (_activeAnimations.ContainsKey(sprite))
            {
                _activeAnimations.Remove(sprite);
            }
        }


        public void Update()
        {
            foreach (var animation in _activeAnimations)
            {
                animation.Value.Update();
                animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
            }
        }


        public void Dispose()
        {
            _activeAnimations.Clear();
        }

    }
}

