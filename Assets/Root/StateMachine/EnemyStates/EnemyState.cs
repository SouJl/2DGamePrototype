using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using System;
using UnityEngine;

namespace Root.PixelGame.StateMachines.Enemy
{
    internal class EnemyState : State
    {
        protected readonly IEnemyCore core;
        protected readonly IAnimatorController animator;
        
        protected float startTime;
        protected bool isExitingState;
        protected bool isAnimationEnd;

        protected readonly float deltaTime;
        protected readonly float fixedTime;

        public EnemyState(
            IStateHandler stateHandler, 
            IStateMachine stateMachine,
            IEnemyCore core,
            IAnimatorController animator) : base(stateHandler, stateMachine)
        {
            this.core 
                = core ?? throw new ArgumentNullException(nameof(core));
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
            animator.StopAnimation();
        }

        public override void InputData()
        {
            base.InputData();
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
            DoChecks();
        }

        protected override void DoChecks()
        {
            isAnimationEnd = animator.IsAnimationEnd;
        }
    }
}
