using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Enemy;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class EnemyState : State
    {
        protected readonly IEnemyCore core;
        protected readonly IEnemyData data;
        protected readonly IAnimatorController animator;
        
        protected float startTime;
        protected bool isExitingState;
        protected bool isAnimationEnd;

        protected float _xAxisInput;
        protected float _yAxisInput;
        
        protected readonly float deltaTime;
        protected readonly float fixedTime;

        public EnemyState(
            IStateHandler stateHandler, 
            IEnemyCore core,
            IEnemyData data,
            IAnimatorController animator) : base(stateHandler)
        {
            this.core 
                = core ?? throw new ArgumentNullException(nameof(core));
            this.data 
                = data ?? throw new ArgumentNullException(nameof(data));
            this.animator
               = animator ?? throw new ArgumentNullException(nameof(animator));

            deltaTime = Time.deltaTime;
            fixedTime = Time.deltaTime;
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

            _xAxisInput = 0;
            _xAxisInput = 0;
            animator.StopAnimation();
        }

        public override void InputData()
        {
            base.InputData();
            _xAxisInput = core.Physic.CurrentVelocity.x;
            _xAxisInput = core.Physic.CurrentVelocity.y;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            animator.Update();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            core.UpdateCoreData(fixedTime);
            core.Physic.Update();
            DoChecks();
        }

        protected override void DoChecks()
        {
            isAnimationEnd = animator.IsAnimationEnd;
        }
    }
}
