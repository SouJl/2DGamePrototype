using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerFallState : PlayerState
    {
        private bool _isGrounded;

        public PlayerFallState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, AnimaState animaState) : base(stateMachine, animatorController, unit, animaState)
        {
        }

        public override void Enter()
        {
            base.Enter();
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
            if (_isGrounded) stateMachine.ChangeState(_player.LandState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            if (Mathf.Abs(_xAxisInput) > _player.MoveModel.MovingThresh)
            {
                _player.CheckFlip(_xAxisInput);

                _player.SetVelocityX(_xAxisInput);
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            _isGrounded = _player.ContactsPoller.CheckGround();
        }
    }
}
