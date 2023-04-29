using PixelGame.Game.Enemy;
using System;
using UnityEngine;

namespace PixelGame.Game.Core
{
    internal class PhysicsMover : IMove
    {
        private readonly IPhysicModel _physic;
        private readonly IEnemyData _data;
        public PhysicsMover(
            IPhysicModel physic, 
            IEnemyData data)
        {
            _physic 
                = physic ?? throw new ArgumentNullException(nameof(physic));
            _data
                = data ?? throw new ArgumentNullException(nameof(data));
        }

        public void Move(Vector2 direction)
        {
            direction *= _data.Speed;

            if (Mathf.Abs(direction.x) > _data.MoveThresh)
            {
                _physic.SetVelocityX(direction.x);
                _physic.SetVelocityY(direction.y);
            }
        }
    }
}
