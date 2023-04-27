using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Enemy;
using UnityEngine;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class EnemyIdleState : EnemyGroundState
    {
        protected bool isIdleTimeOver;

        protected float idleTime;

        public EnemyIdleState(
            IStateHandler stateHandler,
            IEnemyCore core,
            IEnemyData data,
            IAnimatorController animator) : base(stateHandler, core, data, animator)
        {

        }

        public override void Enter()
        {
            base.Enter();
            core.Physic.SetVelocityX(0f);
            isIdleTimeOver = false;
            SetRandomIdleTime();
            animator.StartAnimation(AnimationType.Idle);
        }

        public override void Exit()
        {
            base.Exit();
            isGrounded = false;
            isTouchingWall = false;

            if (core.FlipAfterIdle)
            {
                core.Flip();
                core.SetFlipAfterIdle(false);
            }
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= startTime + idleTime)
            {
                isIdleTimeOver = true;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            core.Physic.SetVelocityX(0f);
        }

        protected override void DoChecks()
        {
            base.DoChecks();    
        }

        private void SetRandomIdleTime()
        {
            idleTime = Random.Range(data.MinIdleTime, data.MaxIdleTime);
        }
    }
}
