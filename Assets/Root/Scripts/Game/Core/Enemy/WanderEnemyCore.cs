using PixelGame.Tool;
using PixelGame.Tool.PlayerSearch;
using System;
using UnityEngine;

namespace PixelGame.Game.Core
{
    internal class WanderEnemyCore : EnemyCore
    {
        public WanderEnemyCore(
            Transform transform, 
            IPhysicModel physic, 
            IPlayerDetection playerDetection, 
            IMove mover, 
            IRotate rotator,
            ISlopeAnaliser slopeAnaliser,
            Transform groundCheck,
            Transform wallCheck) : base(transform, physic, playerDetection, mover, rotator)
        {
            SlopeAnaliser
              = slopeAnaliser ?? throw new ArgumentNullException(nameof(slopeAnaliser));

            GroundCheck = new EnemyGroundCheckModel(groundCheck);
            WallCheck = new WallCheckModel(wallCheck);
        }
    }
}
