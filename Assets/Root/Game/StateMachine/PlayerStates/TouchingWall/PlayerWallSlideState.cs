using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using Root.PixelGame.Game.Core;

namespace Root.PixelGame.Game.StateMachines
{
    internal class PlayerWallSlideState : PlayerTouchingWallState
    {
        public PlayerWallSlideState(
            IStateHandler stateHandler,
            IPlayerCore playerCore,
            IPlayerData playerData,
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.WallSlide);
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
            if (isTouchingWall && isGrab)
            {
                ChangeState(StateType.WallGrabState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (!isExitingState)
            {
                playerCore.Physic.ChangePhysicsMaterial(_noneFriction);
                playerCore.Physic.SetVelocityX(_xAxisInput);
                playerCore.Physic.SetVelocityY(-playerData.WallSlideSpeed);
            }
        }
    }
}
