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
        protected readonly IPhysicModel physic;
        protected readonly IEnemyData data;
        protected readonly IMove mover;
        protected readonly IRotate rotator;

        public EnemyCore(
            Transform transform,
            IPhysicModel physic,
            IEnemyData data,
            IMove mover, 
            IRotate rotator) 
        {
            this.transform = transform;

            this.physic 
                = physic ?? throw new ArgumentNullException(nameof(physic));

            this.data 
                = data ?? throw new ArgumentNullException(nameof(data));
            this.mover 
                = mover ?? throw new ArgumentNullException(nameof(mover));
            this.rotator
                = rotator ?? throw new ArgumentNullException(nameof(rotator));
        }

        public virtual void UpdateCoreData(float time) { }

        public virtual void Move(float time) { }

        public virtual void Rotate(float time) 
        {
            float xInpunt = physic.Rigidbody.velocity.x;

            if (xInpunt != 0 && (xInpunt * rotator.FacingDirection) < 0)
            {
                rotator.Rotate();
            }
        }
    }
}
