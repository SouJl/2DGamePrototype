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

        protected PlayerState(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController) : base(unit, stateMachine, animatorController)
        {
            player = unit as PlayerModel;
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
