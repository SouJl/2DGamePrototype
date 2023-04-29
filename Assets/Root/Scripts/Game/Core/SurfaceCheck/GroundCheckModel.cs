using PixelGame.Tool;
using UnityEngine;

namespace PixelGame.Game.Core
{
    internal interface IGroundCheck
    {
        bool CheckGround();
    }

    internal class GroundCheckModel : IGroundCheck
    {
        private readonly string _configPath = @"Player/GroundCheckConfig";

        private readonly Transform _groundCheck;
        private readonly ISurfaceCheckConfig config;

        public GroundCheckModel(Transform groundCheck)
        {
            _groundCheck = groundCheck;
            config = LoadConfig(_configPath);
        }

        private ISurfaceCheckConfig LoadConfig(string path) =>
            ResourceLoader.LoadObject<SurfaceCheckConfig>(path);

        public bool CheckGround()
        {
            var hit = Physics2D.OverlapCircle(_groundCheck.position, config.CheckDistance, config.CheckLayerMask);

            Color rayColor;
            if (hit != null)
            {
                rayColor = Color.blue;
            }
            else
            {
                rayColor = Color.red;
            }

            Debug.DrawRay(_groundCheck.position, Vector2.down * config.CheckDistance, rayColor);

            return hit != null;
        }
    }
}
