using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerJumpState : PlayerAbilityState
    {
        private bool _isWallSlide;
        private bool _isFall;

        public PlayerJumpState(
            IStateHandler stateHandler, 
            IPlayerCore playerCore, 
            IPlayerData playerData, 
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _isWallSlide = false;
            Jump();
        }

        public override void Exit()
        {
            base.Exit();
            _isWallSlide = false;
            _isFall = false;
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isWallSlide) ChangeState(StateType.WallSlideState);
            if (_isFall) ChangeState(StateType.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }


        private void Jump()
        {
            animator.StartAnimation(AnimationType.InAir);
            playerCore.PhysicModel.SetVelocityY(playerData.JumpForce);
            isAbilityDone = true;
        }
    }
}
