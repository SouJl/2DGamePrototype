using Root.PixelGame.Game.Enemy;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal interface IEnemyCore
    {
        void UpdateCoreData(float time);

        void Move(float time);
        void Rotate(float time);
    }

    internal class EnemyCore : IEnemyCore
    {
        protected readonly Transform transform;
        protected readonly IEnemyData data;
        protected readonly IMove mover;
        protected readonly IRotate rotator;

        public EnemyCore(
            Transform transform,
            IEnemyData data,
            IMove mover, 
            IRotate rotator) 
        {
            this.transform = transform;

            this.data 
                = data ?? throw new ArgumentNullException(nameof(data));
            this.mover 
                = mover ?? throw new ArgumentNullException(nameof(mover));
            this.rotator
                = rotator ?? throw new ArgumentNullException(nameof(rotator));
        }

        public virtual void UpdateCoreData(float time) { }

        public virtual void Move(float time) { }

        public virtual void Rotate(float time) { }
    }
}
