using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool isAbilityDone;

        private bool _isGrounded;

        public PlayerAbilityState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, AnimaState animaState) : base(stateMachine, animatorController, unit, animaState)
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
                if (_isGrounded && _player.UnitComponents.RgdBody.velocity.y < 0.01f)
                {
                    stateMachine.ChangeState(_player.IdleState);
                }
                else
                {
                    stateMachine.ChangeState(_player.InAirState);
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
            _isGrounded = _player.ContactsPoller.CheckGround();
        }
    }
}
