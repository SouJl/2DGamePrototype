using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal class SelfRotator : IRotate
    {
        private readonly Transform _handler;
        
        private int _facingDirection;

        public int FacingDirection => _facingDirection;

        public SelfRotator(Transform handler)
        {
            _handler = handler;
            _facingDirection = 1;
        }

        public void Rotate()
        {
            _facingDirection *= -1;
            _handler.Rotate(0.0f, 180.0f, 0.0f);
        }
    }
}
