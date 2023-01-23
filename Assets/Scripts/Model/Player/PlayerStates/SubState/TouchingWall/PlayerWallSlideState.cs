using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;

namespace PixelGame.Model.StateMachines
{
    public class PlayerWallSlideState : PlayerTouchingWallState
    {
        public PlayerWallSlideState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState) : base(stateMachine, animatorController, unit, playerData, animaState)
        {

        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(isTouchingWall && isGrab) 
            {
                stateMachine.ChangeState(player.WallGrabState);
            }         
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (!isExitingState) 
            {
                rgdBody.sharedMaterial = _noneFriction;
                player.SetVelocityX(_xAxisInput);
                player.SetVelocityY(-playerData.wallSlideSpeed);
            }

        }
    }
}
