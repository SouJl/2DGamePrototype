using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;

namespace PixelGame.Model.StateMachines
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private bool _isWallSlide;
        private bool _isFall;

        public PlayerJumpState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState, bool loop) : base(stateMachine, animatorController, unit, playerData, animaState, loop)
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
            if (_isWallSlide) stateMachine.ChangeState(player.WallSlideState);
            if (_isFall) stateMachine.ChangeState(player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }


        private void Jump() 
        {
            animatorController.StartAnimation(player.SpriteRenderer, AnimaState.InAir, true);
            player.SetVelocityY(playerData.jumpForce);
            isAbilityDone = true;
        }
    }
}
