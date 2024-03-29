﻿using PixelGame.Animation;
using PixelGame.Game;
using PixelGame.Game.Core;
using PixelGame.Tool.Audio;
using System;
using UnityEngine;

namespace PixelGame.Game.StateMachines
{
    internal abstract class PlayerState : State
    {
        protected readonly IPlayerCore playerCore;
        protected readonly IPlayerData playerData;
        protected readonly IAnimatorController animator;

        protected bool isExitingState;
        protected bool isAnimationEnd;

        protected float _xAxisInput;
        protected float _yAxisInput;
        protected PhysicsMaterial2D _fullFriction;
        protected PhysicsMaterial2D _noneFriction;

        protected byte _atackIndex = 0;

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

            _fullFriction = Resources.Load<PhysicsMaterial2D>(@"Materials/FullFrictionMaterial");
            _noneFriction = Resources.Load<PhysicsMaterial2D>(@"Materials/ZeroFrictionMaterial");
        }

        public override void Enter()
        {
            base.Enter();
            DoChecks();
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
