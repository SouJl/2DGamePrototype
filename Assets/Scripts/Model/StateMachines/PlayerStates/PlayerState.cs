using PixelGame.Controllers;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerState : State
    {
        protected PlayerModel _player;

        protected SimplePhysicsMove _moveModel;

        protected PlayerJumpModel _jumpModel;

        protected Rigidbody2D _rgdBody;

        protected float _xAxisInput;
        protected float _yAxisInput;

        protected PhysicsMaterial2D _fullFriction;
        protected PhysicsMaterial2D _noneFriction;

        public PlayerState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit) : base(stateMachine, animatorController)
        {
            _player = unit;
            _moveModel = unit.MoveModel as SimplePhysicsMove;
            _jumpModel = unit.JumpModel as PlayerJumpModel;
            _rgdBody = _player.UnitComponents.RgdBody;

            _fullFriction = Resources.Load<PhysicsMaterial2D>("FullFrictionMaterial");
            _noneFriction = Resources.Load<PhysicsMaterial2D>("ZeroFrictionMaterial");
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
            _player.Slope.SlopeCheck();

            _rgdBody.sharedMaterial = _player.MainMaterial;
        }

        public override void Exit()
        {
            base.Exit();
            _xAxisInput = 0f;
            _yAxisInput = 0f;
        }
    }
}
