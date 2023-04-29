using PixelGame.Animation;
using PixelGame.Game;
using PixelGame.Game.Core;
using UnityEngine;

namespace PixelGame.Game.StateMachines
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
