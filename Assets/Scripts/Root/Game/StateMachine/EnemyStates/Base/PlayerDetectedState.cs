using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Tool.PlayerSearch;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class PlayerDetectedState : State
    {
        protected readonly IEnemyCore core;
        protected readonly IAnimatorController animator;
        protected readonly IPlayerDetectionData data;

        protected bool isPlayerInMinRange;
        protected bool isPlayerInMaxRange;
        protected bool performLongRangeAction;
        protected bool performCloseRangeAction;
        protected bool isGround;

        public PlayerDetectedState(
            IStateHandler stateHandler,
            IAnimatorController animator,
            IEnemyCore core) : base(stateHandler)
        {
            this.core
            = core ?? throw new ArgumentNullException(nameof(core));
            this.animator
               = animator ?? throw new ArgumentNullException(nameof(animator));

            this.data = core.PlayerDetection.Data;
        }

        public override void Enter()
        {
            base.Enter();
            performLongRangeAction = false;
            core.Physic.SetVelocityX(0f);
        }

        public override void Exit()
        {
            base.Exit();
            animator.StopAnimation();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            animator.Update();

            if (Time.time >= startTime + data.LongRangeActionTime)
            {
                performLongRangeAction = true;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            DoChecks();
            core.Physic.SetVelocityX(0f);
        }

        protected override void DoChecks()
        {
            isPlayerInMinRange = core.PlayerDetection.CheckPlayerInMinRange(); 
            isPlayerInMaxRange = core.PlayerDetection.CheckPlayerInMaxRange();
            performCloseRangeAction = core.PlayerDetection.CheckPlayerInCloseRangeAction();
            isGround = core.GroundCheck.CheckGround();
        }
    }
}
