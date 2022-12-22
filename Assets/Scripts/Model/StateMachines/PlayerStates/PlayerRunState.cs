using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerRunState : State
    {
        private Vector2 _horizontalInput;
        
        private bool _isJump;
        private bool _isStay;


        public PlayerRunState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController) 
        {

        }

        public override void Enter()
        {
            base.Enter();

            _isStay = false;
            _isStay = false;
            
            animatorController.StartAnimation(unit.SpriteRenderer, AnimaState.Run, true, 10);
        }

        public override void InputData()
        {
            base.InputData();

            _horizontalInput.x = Input.GetAxis("Horizontal");
            
            _isJump = Input.GetKeyDown(KeyCode.Space);

            _isStay = _horizontalInput.magnitude == 0 && !_isJump ? true : false;  
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isJump) stateMachine.ChangeState(unit.Jump);
            if (_isStay) stateMachine.ChangeState(unit.Idle);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            unit.Move(_horizontalInput);
        }


        public override void Exit()
        {
            base.Exit();
            animatorController.StopAnimation(unit.SpriteRenderer);
        }

    }
}
