﻿using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using Root.PixelGame.Game.Core;
using UnityEngine;

namespace Root.PixelGame.Game.StateMachines
{
    internal class PlayerLandState : PlayerGroundState
    {
        public PlayerLandState(
            IStateHandler stateHandler, 
            IPlayerCore playerCore, 
            IPlayerData playerData, 
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Mathf.Abs(_xAxisInput) > playerData.MoveThresh)
            {
                ChangeState(StateType.MoveState);
            }
            else
            {
                ChangeState(StateType.IdleState);
            }
        }
    }
}