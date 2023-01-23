using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerState : State
    {
        protected PlayerModel player;

        protected PlayerData playerData;

        protected Rigidbody2D rgdBody;

        protected float _xAxisInput;
        protected float _yAxisInput;

        protected PhysicsMaterial2D _fullFriction;
        protected PhysicsMaterial2D _noneFriction;

        protected float startTime;
        protected bool isExitingState;
        private AnimaState _animaState;


        public PlayerState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState) : base(stateMachine, animatorController)
        {
            player = unit;
            this.playerData = playerData;
            rgdBody = player.UnitComponents.RgdBody;

            _fullFriction = Resources.Load<PhysicsMaterial2D>("FullFrictionMaterial");
            _noneFriction = Resources.Load<PhysicsMaterial2D>("ZeroFrictionMaterial");
            _animaState = animaState;
        }

        public override void Enter()
        {
            base.Enter();
            DoChecks();
            startTime = Time.time;
            animatorController.StartAnimation(player.SpriteRenderer, _animaState, true);
            isExitingState = false;
        }


        public override void Exit()
        {
            base.Exit();
            animatorController.StopAnimation(player.SpriteRenderer);
            isExitingState = true;
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
            player.Slope.SlopeCheck();
            rgdBody.sharedMaterial = player.MainMaterial;
            DoChecks();
        }


        protected virtual void DoChecks() { }
    }
}
