using System;
using UnityEngine;

namespace PixelGame.Game.Core
{
    internal class ScaleRotator : IRotate
    {
        private readonly Transform _handler;
        private readonly IPhysicModel _physic;

        private int _facingDirection;

        public int FacingDirection => _facingDirection;

        public ScaleRotator(
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

            if (xInpunt < 0.02f)
            {
                _facingDirection = -1;

                _handler.localScale = new Vector3(
                    -1f * Mathf.Abs(_handler.localScale.x),
                    _handler.localScale.y,
                    _handler.localScale.z);
            }
            else if (xInpunt > -0.02f)
            {
                _facingDirection = 1;

                _handler.localScale = new Vector3(
                    Mathf.Abs(_handler.localScale.x),
                    _handler.localScale.y,
                    _handler.localScale.z);
            }
        }
    }
}
