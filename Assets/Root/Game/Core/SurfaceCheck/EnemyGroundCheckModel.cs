using Root.PixelGame.Tool;
using UnityEngine;


namespace Root.PixelGame.Game.Core
{
    internal class EnemyGroundCheckModel : IGroundCheck
    {
        private readonly string _configPath = @"Enemy/EnemyGroundCheckConfig";

        private readonly Transform _groundCheck;
        private readonly ISurfaceCheckConfig config;

        public EnemyGroundCheckModel(Transform groundCheck)
        {
            _groundCheck = groundCheck;
            config = LoadConfig(_configPath);
        }

        private ISurfaceCheckConfig LoadConfig(string path) =>
            ResourceLoader.LoadObject<SurfaceCheckConfig>(path);

        public bool CheckGround()
        {
            var hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, config.CheckDistance, config.CheckLayerMask);

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

            return hit;
        }
    }
}
