using Root.PixelGame.Tool;
using Root.PixelGame.Tool.PlayerSearch;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal interface IEnemyCore
    {

        Transform Transform { get; }
        IPhysicModel Physic { get; }
        IPlayerDetection PlayerDetection { get; }
        IGroundCheck GroundCheck { get; }
        IWallCheck WallCheck { get; }
        ISlopeAnaliser SlopeAnaliser { get; }

        int FacingDirection { get; }
        bool FlipAfterIdle { get; }

        void Flip();

        void UpdateCoreData(float time);
        void Move(float time);
        void Rotate(float time);
        void SetFlipAfterIdle(bool isFlip);
    }

    internal abstract class EnemyCore : IEnemyCore
    {
        protected readonly Transform transform;
        protected readonly IMove mover;
        protected readonly IRotate rotator;

        public IPhysicModel Physic { get; private set; }
        public IPlayerDetection PlayerDetection { get; protected set; }

        public IGroundCheck GroundCheck { get; protected set; }

        public IWallCheck WallCheck { get; protected set; }
        public ISlopeAnaliser SlopeAnaliser { get; protected set; }
       
        public int FacingDirection { get; private set; }

        public bool FlipAfterIdle { get; private set; }

        public Transform Transform => transform;

        public EnemyCore(
            Transform transform,
            IPhysicModel physic,
            IPlayerDetection playerDetection,
            IMove mover, 
            IRotate rotator) 
        {
            this.transform = transform;

            Physic
                = physic ?? throw new ArgumentNullException(nameof(physic));

            PlayerDetection
               = playerDetection ?? throw new ArgumentNullException(nameof(playerDetection));

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

        public virtual void SetFlipAfterIdle(bool isFlip)
        {
            FlipAfterIdle = isFlip;
        }
    }
}
