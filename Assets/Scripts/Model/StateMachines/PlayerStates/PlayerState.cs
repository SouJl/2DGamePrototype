using PixelGame.Controllers;
using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerState : State
    {
        protected PlayerModel player;

        protected IMove _moveModel;
        protected float _xAxisInput;
        protected float _yAxisInput;

        public PlayerState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit) : base(stateMachine, animatorController)
        {
            player = unit;
            _moveModel = unit.MoveModel;
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

        public override void Exit()
        {
            base.Exit();
            _xAxisInput = 0f;
            _yAxisInput = 0f;
        }
    }
}
