using Root.PixelGame.Tool;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal class WanderEnemyCore : EnemyCore
    {
        private readonly float _speed;

        public WanderEnemyCore(
            Transform transform,
            IPhysicModel physic,
            IMove mover,
            IRotate rotator,
            ISlopeAnaliser slopeAnaliser,
            Transform groundCheck,
            Transform wallCheck,
            float speed) : base(transform, physic, mover, rotator)
        {
            _speed = speed;
            
            SlopeAnaliser 
                = slopeAnaliser ?? throw new ArgumentNullException(nameof(slopeAnaliser));
            
            GroundCheck = new EnemyGroundCheckModel(groundCheck);
            WallCheck = new WallCheckModel(wallCheck);
        }


        public override bool CheckPlayerInRange()
        {
            return false;
        }
    }
}
