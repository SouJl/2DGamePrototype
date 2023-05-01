using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Tool.Audio;

namespace PixelGame.Game.StateMachines
{
    internal class PlayerJumpState : PlayerAbilityState
    {
        private bool _isTouchingWall;
        private bool _isTouchingLedge;

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
            _isTouchingWall = false;
            _isTouchingLedge = false;
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
            if (_isTouchingWall && !_isTouchingLedge)
            {
                ChangeState(StateType.LedgeState);
                return;
            }
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

        protected override void DoChecks()
        {
            base.DoChecks();
            _isTouchingWall = playerCore.WallCheck.CheckWallFront(playerCore.FacingDirection);

            _isTouchingLedge = playerCore.LedgeCheck.CheckLedgeTouch(playerCore.FacingDirection);
            if (_isTouchingWall && !_isTouchingLedge)
            {
                playerCore.LedgeCheck.LedgePosition = playerCore.CurrentPosition;
            }
        }

    }
}
