using Root.PixelGame.Animation;
using Root.PixelGame.Game;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerAbilityState : PlayerState
    {
        protected bool isAbilityDone;

        private bool _isGrounded;

        public PlayerAbilityState(
            IStateHandler stateHandler,
            IPlayerCore playerCore,
            IPlayerData playerData,
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }


        public override void Enter()
        {
            base.Enter();
            isAbilityDone = false;
        }

        public override void Exit()
        {
            base.Exit();
            _isGrounded = false;
            isAbilityDone = false;
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (isAbilityDone)
            {
                if (_isGrounded && playerCore.Physic.Rigidbody.velocity.y < 0.01f)
                {
                    ChangeState(StateType.IdleState);
                }
                else
                {
                    ChangeState(StateType.InAirState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            _isGrounded = playerCore.GroundCheck.CheckGround();
        }
    }
}
