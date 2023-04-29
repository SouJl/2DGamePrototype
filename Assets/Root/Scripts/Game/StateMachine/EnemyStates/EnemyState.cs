using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Game.Enemy;
using System;
using UnityEngine;

namespace PixelGame.Game.StateMachines.Enemy
{
    internal class EnemyState : State
    {
        protected readonly IEnemyCore core;
        protected readonly IEnemyData data;
        protected readonly IAnimatorController animator;
        
        protected bool isExitingState;
        protected bool isAnimationEnd;
     
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
            core.Physic.Update();
            DoChecks();
        }

        protected override void DoChecks()
        {
            isAnimationEnd = animator.IsAnimationEnd;
        }
    }
}
