﻿using PixelGame.Tool;
using UnityEngine;

namespace PixelGame.Game.Core
{
    internal interface IWallCheck
    {
        bool CheckWallFront(int facingDirection);
        bool CheckWallBack(int facingDirection);
    }

    internal class WallCheckModel : IWallCheck
    {

        private readonly string _configPath = @"Configs/Player/WallCheckConfig";

        private readonly Transform _wallCheck;
        private readonly ISurfaceCheckConfig config;

        public WallCheckModel(Transform wallCheck)
        {
            _wallCheck = wallCheck;
            config = LoadConfig(_configPath);
        }

        private ISurfaceCheckConfig LoadConfig(string path) => 
            ResourceLoader.LoadObject<SurfaceCheckConfig>(path);

        public bool CheckWallFront(int facingDirection) =>
            Physics2D.Raycast(_wallCheck.position, Vector2.right * facingDirection, config.CheckDistance, config.CheckLayerMask);
        public bool CheckWallBack(int facingDirection) => 
            Physics2D.Raycast(_wallCheck.position, Vector2.left * facingDirection, config.CheckDistance, config.CheckLayerMask);
    }
}
