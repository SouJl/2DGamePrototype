using Root.PixelGame.Components.Core;
using System;
using UnityEngine;

namespace Root.PixelGame.Tool.PlayerSearch
{
    internal interface IPlayerDetection
    {
        bool CheckPlayerInMinRange();
        bool CheckPlayerInMaxRange();
        bool CheckPlayerInCloseAction();
    }

    internal class PlayerDetectionTool : IPlayerDetection
    {
        private readonly Transform _handler;
        private readonly Transform _playerCheck;
        private readonly IPlayerDetectionData _data;

        public PlayerDetectionTool(IPlayerDetectionComponent playerDetectionComponent)
        {
            _handler = playerDetectionComponent.HandlerTransform;
            
            _playerCheck = playerDetectionComponent.PlayerCheckTransform;
            
            _data 
                = playerDetectionComponent.Config 
                ?? throw new ArgumentNullException(nameof(playerDetectionComponent.Config));
        }

        public bool CheckPlayerInCloseAction()
        {
            return Physics2D.Raycast(_playerCheck.position, _handler.right, _data.CloseActionDistance, _data.PlaterMask);
        }

        public bool CheckPlayerInMaxRange()
        {
            return Physics2D.Raycast(_playerCheck.position, _handler.right, _data.MaxCheckDistance, _data.PlaterMask);
        }

        public bool CheckPlayerInMinRange()
        {
            return Physics2D.Raycast(_playerCheck.position, _handler.right, _data.MinCheckDistance, _data.PlaterMask);
        }
    }
}
