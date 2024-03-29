﻿using PixelGame.Animation;
using PixelGame.Game;
using PixelGame.Game.Core;
using UnityEngine;

namespace PixelGame.Game.StateMachines
{
    internal class PlayerWallJumpState : PlayerAbilityState
    {
        public PlayerWallJumpState(
            IStateHandler stateHandler,
            IPlayerCore playerCore,
            IPlayerData playerData,
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }
        public override void Enter()
        {
            base.Enter();
            playerCore.Physic.SetVelocityX(0f);
            animator.StartAnimation(AnimationType.InAir);
            playerCore.Physic.SetVelocity(playerData.WallJumpForce, playerData.WallJumpAngle, playerCore.WallJumpDirection);
            playerCore.CheckFlip(playerCore.WallJumpDirection);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if (Time.time >= startTime + playerData.WallJumpTime)
            {
                isAbilityDone = true;
            }
        }
    }
}
