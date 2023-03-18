﻿using Root.PixelGame.Game.Core;
using Root.PixelGame.Tool;
using UnityEngine;
using System;

namespace Root.PixelGame.Game
{
    internal interface IPlayerCore
    {
        IPhysicModel Physic { get; }
        ISlopeAnaliser SlopeAnaliser { get; }
        IGroundCheck GroundCheck { get; }
        IWallCheck WallCheck { get; }

        int FacingDirection { get; }

        int WallJumpDirection { get; }

        void CheckFlip(float xInpunt);

        void DetermineWallJumpDirection(bool isTouchingWall);
    }

    internal class PlayerCore : IPlayerCore
    {
        private readonly Transform _transform;

        public IPhysicModel Physic { get; private set; }
        public ISlopeAnaliser SlopeAnaliser { get; private set; }
        public IGroundCheck GroundCheck { get; private set; }
        public IWallCheck WallCheck { get; private set; }

        public int FacingDirection { get; private set; }

        public int WallJumpDirection { get; private set; }

        public PlayerCore(
            Transform transform, 
            IPhysicModel physic,
            ISlopeAnaliser slopeAnaliser,
            IGroundCheck groundCheck,
            IWallCheck wallCheck)
        {
            _transform = transform;

            Physic 
                = physic ?? throw new ArgumentNullException(nameof(physic));

            SlopeAnaliser 
                = slopeAnaliser ?? throw new ArgumentNullException(nameof(slopeAnaliser));
            GroundCheck 
                = groundCheck ?? throw new ArgumentNullException(nameof(groundCheck));
            WallCheck
              = wallCheck ?? throw new ArgumentNullException(nameof(wallCheck));

            FacingDirection = 1;
        }

        public void CheckFlip(float xInpunt)
        {
            if (xInpunt != 0 && (xInpunt * FacingDirection) < 0)
            {
                FacingDirection *= -1;
                _transform.Rotate(0.0f, 180.0f, 0.0f);
            }
        }

        public void DetermineWallJumpDirection(bool isTouchingWall)
        {
            WallJumpDirection = (isTouchingWall ? -1 : 1) * FacingDirection;
        }
    }
}
