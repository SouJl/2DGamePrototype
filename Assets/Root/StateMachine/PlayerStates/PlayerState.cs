using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using Root.PixelGame.Game.Core;
using System;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal abstract class PlayerState : State
    {
        protected readonly IPlayerCore playerCore;
        protected readonly IPlayerData playerData;
        protected readonly IAnimatorController animator;

        protected float startTime;

        protected bool isExitingState;
        protected bool isAnimationEnd;

        protected float _xAxisInput;
        protected float _yAxisInput;
        protected PhysicsMaterial2D _fullFriction;
        protected PhysicsMaterial2D _noneFriction;

        protected PlayerState(
            IStateHandler stateHandler,
            IPlayerCore playerCore,
            IPlayerData playerData,
            IAnimatorController animator) : base(stateHandler)
        {
            this.playerCore
               = playerCore ?? throw new ArgumentNullException(nameof(playerCore));

            this.playerData
                = playerData ?? throw new ArgumentNullException(nameof(playerData));

            this.animator
                = animator ?? throw new ArgumentNullException(nameof(animator));

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
            animator.StopAnimation();
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
            playerCore.SlopeAnaliser.SlopeCheck();
            playerCore.Physic.Update();
            DoChecks();
        }

        protected override void DoChecks()
        {
            isAnimationEnd = animator.IsAnimationEnd;
        }
    }
}
