using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Tool.Audio;

namespace Root.PixelGame.Game.StateMachines
{
    internal class PlayerJumpState : PlayerAbilityState
    {
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
            Jump();
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
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }


        private void Jump()
        {
            animator.StartAnimation(AnimationType.InAir);
            playerCore.Physic.SetVelocityY(playerData.JumpForce);
            AudioManager.Instance.PlaySFX(SFXAudioType.Player, "PlayerJump");
            isAbilityDone = true;
        }
    }
}
