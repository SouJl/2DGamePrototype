﻿using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Game.Enemy;

namespace PixelGame.Game.StateMachines.Enemy
{
    internal class EnemyTakeDamageState : EnemyState
    {
        public EnemyTakeDamageState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IEnemyData data, 
            IAnimatorController animator) : base(stateHandler, core, data, animator)
        {
        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.TakeDamage);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (isAnimationEnd)
            {
                ChangeState(StateType.IdleState);
                return;
            }
        }
    }
}
