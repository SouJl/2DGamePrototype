﻿using Root.PixelGame.Tool;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal interface IEnemyCore
    {
        IPhysicModel Physic { get; }
        IGroundCheck GroundCheck { get; }
        IWallCheck WallCheck { get; }
        ISlopeAnaliser SlopeAnaliser { get; }

        int FacingDirection { get; }

        void Flip();

        void UpdateCoreData(float time);
        void Move(float time);
        void Rotate(float time);
    }

    internal class EnemyCore : IEnemyCore
    {
        protected readonly Transform transform;
        protected readonly IMove mover;
        protected readonly IRotate rotator;

        public IPhysicModel Physic { get; private set; }

        public IGroundCheck GroundCheck { get; protected set; }

        public IWallCheck WallCheck { get; protected set; }
        public ISlopeAnaliser SlopeAnaliser { get; protected set; }

        public int FacingDirection { get; private set; }

        public EnemyCore(
            Transform transform,
            IPhysicModel physic,
            IMove mover, 
            IRotate rotator) 
        {
            this.transform = transform;

            Physic
                = physic ?? throw new ArgumentNullException(nameof(physic));
            this.mover 
                = mover ?? throw new ArgumentNullException(nameof(mover));
            this.rotator
                = rotator ?? throw new ArgumentNullException(nameof(rotator));

            FacingDirection = 1;
        }

        public virtual void UpdateCoreData(float time) { }

        public virtual void Move(float time) { }

        public virtual void Rotate(float time) { }

        public virtual void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }
}
