using Root.PixelGame.Game.Core;
using Root.PixelGame.Tool;
using UnityEngine;

namespace Root.PixelGame.Game
{
    internal interface IPlayerCore
    {
        ISlopeAnaliser SlopeAnaliser { get; }

        IPhysicModel PhysicModel { get; }

        int FacingDirection { get; }

        void CheckFlip(float xInpunt);

        bool CheckGround();
    }

    internal class PlayerCore : IPlayerCore
    {
        private readonly Transform _transform;
        private readonly Collider2D _collider;

        private readonly Transform _groundCheck;
        private readonly LayerMask _groundLayerMask;

        public ISlopeAnaliser SlopeAnaliser { get; private set; }
        public IPhysicModel PhysicModel  { get; private set; }

        public int FacingDirection { get; private set; }

        public PlayerCore(Transform transform, Rigidbody2D rigidbody, Collider2D collider, Transform groundCheck, LayerMask groundLayerMask)
        {
            _transform = transform;
            _collider = collider;
            _groundCheck = groundCheck;
            _groundLayerMask = groundLayerMask;

            SlopeAnaliser = new SlopeAnaliserTool(rigidbody, _collider);
            PhysicModel = new PhysicModel(rigidbody);

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

        public bool CheckGround()
        {
            var hit = Physics2D.OverlapCircle(_groundCheck.position, 0.5f, _groundLayerMask);

            Color rayColor;
            if (hit != null)
            {
                rayColor = Color.blue;
            }
            else
            {
                rayColor = Color.red;
            }

            Debug.DrawRay(_groundCheck.position, Vector2.down * 0.5f, rayColor);

            return hit != null;
        }
    }
}
