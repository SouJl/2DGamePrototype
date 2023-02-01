using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerWallJumpState : PlayerAbilityState
    {
        public PlayerWallJumpState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState, bool loop) : base(stateMachine, animatorController, unit, playerData, animaState, loop)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocityX(0f);
            player.SetVelocity(playerData.wallJumpForce, playerData.wallJumpAngle, player.WallJumpDirection);
            player.CheckFlip(player.WallJumpDirection);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
       
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if (Time.time >= startTime + playerData.wallJumpTime)
            {
                isAbilityDone = true;
            }
        }


    }
}
