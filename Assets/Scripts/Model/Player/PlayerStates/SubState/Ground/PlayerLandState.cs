using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerLandState : PlayerGroundState
    {
        public PlayerLandState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState) : base(stateMachine, animatorController, unit, playerData, animaState)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Mathf.Abs(_xAxisInput) > playerData.moveThresh)
            {
                stateMachine.ChangeState(player.RunState);
            }
            else 
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }
}
