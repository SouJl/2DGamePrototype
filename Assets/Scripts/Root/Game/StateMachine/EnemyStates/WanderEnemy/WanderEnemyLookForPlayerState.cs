﻿using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Enemy;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class WanderEnemyLookForPlayerState : LookForPlayerState
    {
        public WanderEnemyLookForPlayerState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IEnemyData data, 
            IAnimatorController animator) : base(stateHandler, core, data, animator)
        {

        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.LookForPlayer);
        }

        public override void Exit()
        {
            base.Exit();
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (isPlayerInMinange)
            {
                ChangeState(StateType.PlayerDetected);
                return;
            }
            if (isAllTurnsTimeDone)
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
