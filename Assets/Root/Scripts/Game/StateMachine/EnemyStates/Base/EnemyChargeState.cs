using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Game.Enemy;
using UnityEngine;

namespace PixelGame.Game.StateMachines.Enemy
{
    internal class EnemyChargeState : EnemyState
    {
        protected bool isPlayerInMinange;
        protected bool isGround;
        protected bool isDetectingWall;
        protected bool isChargeTimeOver;
        protected bool performCloseRangeAction;

        public EnemyChargeState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IEnemyData data, 
            IAnimatorController animator) : base(stateHandler, core, data, animator)
        {

        }

        public override void Enter()
        {
            base.Enter();
            isChargeTimeOver = false;
            core.Physic.SetVelocityX(data.ChargeSpeed * core.FacingDirection);
        }
        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Time.time >= startTime + data.ChargeTime)
            {
                isChargeTimeOver = true;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            core.Physic.SetVelocityX(data.ChargeSpeed * core.FacingDirection);
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            isPlayerInMinange = core.PlayerDetection.CheckPlayerInMinRange();
            isGround = core.GroundCheck.CheckGround();
            isDetectingWall = core.WallCheck.CheckWallFront(core.FacingDirection);

            performCloseRangeAction = core.PlayerDetection.CheckPlayerInCloseRangeAction();
        }
    }
}
