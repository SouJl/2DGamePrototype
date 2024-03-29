﻿using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Game.Enemy;

namespace PixelGame.Game.StateMachines.Enemy
{
    internal class WanderEnemyIdleState : EnemyIdleState
    {
        public WanderEnemyIdleState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IEnemyData data, 
            IAnimatorController animator) : base(stateHandler, core, data, animator)
        {

        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isPlayerInMinRange)
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
        }

        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
