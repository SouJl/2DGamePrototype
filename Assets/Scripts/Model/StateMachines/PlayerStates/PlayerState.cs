using PixelGame.Controllers;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerState : State
    {
        protected PlayerModel _player;

        protected PlayerMovementModel _moveModel;

        protected PlayerJumpModel _jumpModel;

        protected float _xAxisInput;
        protected float _yAxisInput;

        public PlayerState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit) : base(stateMachine, animatorController)
        {
            _player = unit;
            _moveModel = unit.MoveModel as PlayerMovementModel;
            _jumpModel = unit.JumpModel as PlayerJumpModel;
        }

        public override void Enter()
        {
            base.Enter();
            _xAxisInput = 0f;
            _yAxisInput = 0f;
        }

        public override void InputData()
        {
            base.InputData();
            _xAxisInput = Input.GetAxis("Horizontal");
            _yAxisInput = Input.GetAxis("Vertical");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            _xAxisInput = 0f;
            _yAxisInput = 0f;
        }
    }
}
