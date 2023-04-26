﻿using Root.PixelGame.Animation;
using Root.PixelGame.Game.AI;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Enemy;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class ChaserEnemyIdleState : EnemyState
    {
        protected readonly IAIBehaviour _aIBehaviour;

        private bool isPlayerInRange;
        private bool isIdleTimeOver;
        private float idleTime;

        public ChaserEnemyIdleState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IEnemyData data, 
            IAnimatorController animator,
            IAIBehaviour aIBehaviour) : base(stateHandler, core, data, animator)
        {
            _aIBehaviour 
                = aIBehaviour ?? throw new ArgumentNullException(nameof(aIBehaviour));
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
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (Time.time >= startTime + idleTime)
            {
                isIdleTimeOver = true;
            }

            if (isPlayerInRange)
            {
                ChangeState(StateType.PlayerDetected);
                return;
            }
            else if (isIdleTimeOver)
            {
                ChangeState(StateType.MoveState);
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
            isPlayerInRange = core.CheckPlayerInRange();
        }

        private void SetRandomIdleTime()
        {
            idleTime = UnityEngine.Random.Range(data.MinIdleTime, data.MaxIdleTime);
        }
    }
}
