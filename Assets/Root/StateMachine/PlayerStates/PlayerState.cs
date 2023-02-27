using Root.PixelGame.Game;
using System;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerState : State
    {
        protected readonly IPlayerCore playerCore;
        protected readonly IPlayerData playerData;

        protected float startTime;

        protected bool isExitingState;
        protected bool isAnimationEnd;

        protected float _xAxisInput;
        protected float _yAxisInput;
        protected PhysicsMaterial2D _fullFriction;
        protected PhysicsMaterial2D _noneFriction;

        public PlayerState(
            IStateHandler stateHandler,
            IPlayerCore playerCore,
            IPlayerData playerData) : base(stateHandler)
        {
       
            this.playerCore 
                = playerCore ?? throw new ArgumentNullException(nameof(playerCore));
            
            this.playerData 
                = playerData ?? throw new ArgumentNullException(nameof(playerData));

            _fullFriction = Resources.Load<PhysicsMaterial2D>("Materail/FullFrictionMaterial");
            _noneFriction = Resources.Load<PhysicsMaterial2D>("Materail/ZeroFrictionMaterial");
        }

        public override void Enter()
        {
            base.Enter();
            DoChecks();
            startTime = Time.time;
            isExitingState = false;
        }

        public override void Exit()
        {
            base.Exit();
            isExitingState = true;
            isAnimationEnd = false;
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

        protected override void DoChecks()
        {

        }
    }
}
