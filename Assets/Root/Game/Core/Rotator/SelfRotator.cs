using System;
using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal class SelfRotator : IRotate
    {
        private readonly Transform _handler;
        private readonly IPhysicModel _physic;

        private int _facingDirection;

        public int FacingDirection => _facingDirection;

        public SelfRotator(
            Transform handler,
            IPhysicModel physic)
        {
            _handler = handler;
            
            _physic
                = physic ?? throw new ArgumentNullException(nameof(physic));

            _facingDirection = 1;
        }

        public void Rotate()
        {
            float xInpunt = _physic.Rigidbody.velocity.x;
            if (xInpunt != 0 && ( xInpunt * _facingDirection) < 0)
            {
                _facingDirection *= -1;
                _handler.Rotate(0.0f, 180.0f, 0.0f);
            }
        }
    }
}
