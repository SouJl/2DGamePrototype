using PixelGame.Controllers;
using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerState : State
    {
        protected PlayerModel player;

        protected IMove _moveModel;
        protected IJump _jumpModel;
        protected float _xAxisInput;
        protected float _yAxisInput;

        private bool _isFall;

        public PlayerState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit) : base(stateMachine, animatorController)
        {
            player = unit;
            _moveModel = unit.MoveModel;
            _jumpModel = unit.JumpModel;
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
            if (_isFall) stateMachine.ChangeState(player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (!player.ContactsPoller.IsGrounded && _jumpModel.GetVelocity().y < -_jumpModel.FlyThershold)
            {
                _isFall = true;
            }
        }

        public override void Exit()
        {
            base.Exit();
            _xAxisInput = 0f;
            _yAxisInput = 0f;
            _isFall = false;
        }
    }
}
