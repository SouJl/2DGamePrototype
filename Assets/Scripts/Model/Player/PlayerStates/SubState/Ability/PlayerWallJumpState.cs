using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerWallJumpState : PlayerAbilityState
    {
        private int _wallJumpDir;

        public PlayerWallJumpState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState) : base(stateMachine, animatorController, unit, playerData, animaState)
        {
        }

        public override void Enter()
        {
            base.Enter();
            //_player.SetVelocityY(pla)
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(Time.time >= startTime + playerData.wallJumpTime) 
            {
                isAbilityDone = true;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }


    }
}
