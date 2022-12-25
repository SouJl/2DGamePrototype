using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerJumpState : State 
    {
        private Vector2 _horizontalInput;
        private bool _isGround;

        public PlayerJumpState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController)
        {

        }

        public override void Enter()
        {
            base.Enter();
            _isGround = false;
            animatorController.StartAnimation(unit.SpriteRenderer, AnimaState.Jump, true);
        }

        public override void InputData()
        {
            base.InputData();
            _horizontalInput.x = Input.GetAxis("Horizontal");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isGround) stateMachine.ChangeState(unit.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            unit.SpriteRenderer.flipX = _horizontalInput.x < 0;
            unit.MoveModel.Move(_horizontalInput);

            _isGround = unit.ContactsPoller.IsGrounded;
        }

        public override void Exit()
        {
            base.Exit();
            _horizontalInput = Vector2.zero;
            _isGround = false;
            animatorController.StopAnimation(unit.SpriteRenderer);
        }
    }
}
