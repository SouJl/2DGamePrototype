using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal interface IGroundCheck
    {
        bool CheckGround();
    }

    internal class GroundCheckModel : IGroundCheck
    {
        private readonly string _configPath = @"Player/GroundCheckConfig";

        private readonly Transform _groundCheck;
        private readonly IGroundCheckConfig config;

        public GroundCheckModel(Transform groundCheck)
        {
            _groundCheck = groundCheck;
            config = LoadConfig(_configPath);
        }

        private IGroundCheckConfig LoadConfig(string path)
        {
            var config = Resources.Load<GroundCheckConfig>(path);

            return config;
        }

        public bool CheckGround()
        {
            var hit = Physics2D.OverlapCircle(_groundCheck.position, config.CheckRadius, config.GroundLayerMask);

            Color rayColor;
            if (hit != null)
            {
                rayColor = Color.blue;
            }
            else
            {
                rayColor = Color.red;
            }

            Debug.DrawRay(_groundCheck.position, Vector2.down * config.CheckRadius, rayColor);

            return hit != null;
        }
    }
}
