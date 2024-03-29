﻿using PixelGame.Components.AI;
using System;
using UnityEngine;

namespace PixelGame.Game.AI
{
    internal interface IAIBehaviour
    {
        void Init();
        void Deinit();
        Vector2 GetNewVelocity(Vector2 fromPosition);
        void UpdateParameters(float time);

        bool CheckTargetReached();
    }

    internal abstract class BaseAI : IAIBehaviour
    {
        protected readonly IAIData data;
        public BaseAI(IAIData data)
        {
            this.data 
                = data ?? throw new ArgumentNullException(nameof(data));
        }

        public abstract void Init();
        public abstract void Deinit();

        public abstract Vector2 GetNewVelocity(Vector2 fromPosition);

        public virtual void UpdateParameters(float time) { }

        public abstract bool CheckTargetReached();
    }
}
