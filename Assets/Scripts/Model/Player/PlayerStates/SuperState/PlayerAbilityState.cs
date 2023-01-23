using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;

namespace PixelGame.Model.StateMachines
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool isAbilityDone;

        private bool _isGrounded;

        public PlayerAbilityState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState) : base(stateMachine, animatorController, unit, playerData, animaState)
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
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(isAbilityDone)
            {
                if (_isGrounded && player.UnitComponents.RgdBody.velocity.y < 0.01f)
                {
                    stateMachine.ChangeState(player.IdleState);
                }
                else
                {
                    stateMachine.ChangeState(player.InAirState);
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
            _isGrounded = player.ContactsPoller.CheckGround();
        }
    }
}
