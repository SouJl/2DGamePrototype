using PixelGame.Controllers;
using PixelGame.Enumerators;
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

        protected float startTime;

        private AnimaState _animaState;


        public PlayerState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, AnimaState animaState) : base(stateMachine, animatorController)
        {
            _player = unit;
            _moveModel = unit.MoveModel as SimplePhysicsMove;
            _jumpModel = unit.JumpModel as PlayerJumpModel;
            _rgdBody = _player.UnitComponents.RgdBody;

            _fullFriction = Resources.Load<PhysicsMaterial2D>("FullFrictionMaterial");
            _noneFriction = Resources.Load<PhysicsMaterial2D>("ZeroFrictionMaterial");
            _animaState = animaState;
        }

        public override void Enter()
        {
            base.Enter();
            DoChecks();
            startTime = Time.time;
            animatorController.StartAnimation(_player.SpriteRenderer, _animaState, true);
        }


        public override void Exit()
        {
            base.Exit();
            animatorController.StopAnimation(_player.SpriteRenderer);
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

            DoChecks();
        }


        protected virtual void DoChecks() { }
    }
}
