using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;

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
           // _player.SetVelocityY()
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
           // if(Time.time >= startTime + )
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public void DetermineWallJumpDirection(bool isTouchingWall)
        {
            _wallJumpDir = (isTouchingWall ? -1 : 1) * player.FacingDirection;
        }

    }
}
