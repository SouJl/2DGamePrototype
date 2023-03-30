using System;
using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal interface IEnemyCore
    {
        void Move(float time);
        void Rotate(float time);
    }

    internal class EnemyCore : IEnemyCore
    {
        private readonly IMove _mover;
        private readonly IRotate _rotator;

        public EnemyCore(
            IMove mover, 
            IRotate rotator) 
        {
            _mover 
                = mover ?? throw new ArgumentNullException(nameof(mover));
            _rotator
                = rotator ?? throw new ArgumentNullException(nameof(rotator));
        }

        public void Move(float time)
        {
            throw new NotImplementedException();
        }

        public void Rotate(float time)
        {
            throw new NotImplementedException();
        }
    }
}
