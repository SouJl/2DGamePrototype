using Root.PixelGame.Animation;
using Root.PixelGame.Game;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerJumpState : PlayerAbilityState
    {
        public PlayerJumpState(
            IStateHandler stateHandler,
            IStateMachine stateMachine,
            IPlayerCore playerCore,
            IPlayerData playerData,
            IAnimatorController animator) : base(stateHandler, stateMachine, playerCore, playerData, animator)
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
            isAbilityDone = true;
        }
    }
}
