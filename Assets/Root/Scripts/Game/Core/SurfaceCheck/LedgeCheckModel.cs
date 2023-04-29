using PixelGame.Tool;
using System;
using UnityEngine;

namespace PixelGame.Game.Core
{
    internal interface ILedgeCheck
    {
        Vector2 LedgePosition { get; set; }
        bool CheckLedgeTouch(int facingDirection);
        Vector2 DetermineCornerPos(int facingDirection);
        bool CheckCornerSpace(Vector2 _cornerPos, int facingDirection);
    }

    internal class LedgeCheckModel: ILedgeCheck
    {
        private readonly string _configPath = @"Configs/Player/LedgeCheckConfig";

        private readonly Transform _wallCheck;
        private readonly Transform _ledgeCheck;
        private readonly float _standColliderHeight;
        private readonly ISurfaceCheckConfig config;

        public Vector2 LedgePosition { get; set; }

        public LedgeCheckModel(
            Transform wallCheck, 
            Transform ledgeCheck, 
            float standColliderHeight)
        {
            _wallCheck = wallCheck;
            _ledgeCheck = ledgeCheck;
            _standColliderHeight = standColliderHeight;
            config = LoadConfig(_configPath);
        }

        private ISurfaceCheckConfig LoadConfig(string path) => 
            ResourceLoader.LoadObject<SurfaceCheckConfig>(path);

        public bool CheckLedgeTouch(int facingDirection)
        {
            var rayColor = Color.green;
            Debug.DrawRay(_ledgeCheck.position, Vector2.right * facingDirection * config.CheckDistance, rayColor);
            return Physics2D.Raycast(
                _ledgeCheck.position, 
                Vector2.right * facingDirection, 
                config.CheckDistance, 
                config.CheckLayerMask);
        }

        public bool CheckCornerSpace(Vector2 _cornerPos, int facingDirection)
        {
            return Physics2D.Raycast(
                _cornerPos + (Vector2.up * 0.015f) + (Vector2.right * facingDirection * 0.015f), 
                Vector2.up,
                _standColliderHeight, 
                config.CheckLayerMask);
        }

  
        public Vector2 DetermineCornerPos(int facingDirection)
        {
            Vector2 result = Vector2.zero;
            RaycastHit2D xHit = Physics2D.Raycast(_wallCheck.position, Vector2.right * facingDirection, config.CheckDistance, config.CheckLayerMask);
            float xDist = xHit.distance;
            result.Set((xDist + 0.015f) * facingDirection, 0f);
            RaycastHit2D yHit = Physics2D.Raycast(_ledgeCheck.position + (Vector3)result, Vector2.down, _ledgeCheck.position.y - _wallCheck.position.y, config.CheckLayerMask);
            float yDist = yHit.distance;
            result.Set(_wallCheck.position.x + (xDist * facingDirection), _ledgeCheck.position.y - yDist);
            return result;
        }
    }
}
