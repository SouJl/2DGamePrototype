using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerIdleState : State
    {
        private float _xAxisInput;

        private bool _isJump;
        private bool _isRun;


        public PlayerIdleState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController)
        {

        }

        public override void Enter()
        {
            base.Enter();
            _isJump = false;
            _isRun = false;
            animatorController.StartAnimation(unit.SpriteRenderer, AnimaState.Idle, true);
        }

        public override void InputData()
        {
            base.InputData();
            _xAxisInput = Input.GetAxis("Horizontal");
            _isRun = Mathf.Abs(_xAxisInput) > unit.MoveModel.MovingThresh;

            _isJump = Input.GetKeyDown(KeyCode.Space);
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_isJump) stateMachine.ChangeState(unit.Jump);
            if (_isRun) stateMachine.ChangeState(unit.Run);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            animatorController.StopAnimation(unit.SpriteRenderer);
        }

    }
}
