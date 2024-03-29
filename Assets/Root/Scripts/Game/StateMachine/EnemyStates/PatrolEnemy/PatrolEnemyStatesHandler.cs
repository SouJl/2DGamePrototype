﻿using System;
using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Game.StateMachines.Enemy;
using System.Collections.Generic;
using PixelGame.Game.Enemy;

namespace PixelGame.Game.StateMachines
{
    internal class PatrolEnemyStatesHandler : StateHandler
    {
        private readonly IEnemyCore _core;
        private readonly IEnemyData _data;
        private readonly IAnimatorController _animator;

        public PatrolEnemyStatesHandler(
            IEnemyCore core,
            IEnemyData data,
            IAnimatorController animator)
        {
            _core
              = core ?? throw new ArgumentNullException(nameof(core));
            _data
              = data ?? throw new ArgumentNullException(nameof(data));
            _animator
                = animator ?? throw new ArgumentNullException(nameof(animator));
        }

        protected override IDictionary<StateType, IState> CreateStates()
        {
            var states = new Dictionary<StateType, IState>();

            states[StateType.IdleState] = new EnemyIdleState(this, _core, _data, _animator);
            states[StateType.MoveState] = new EnemyMoveState(this, _core, _data, _animator);
            states[StateType.TakeDamage] = new EnemyTakeDamageState(this, _core, _data, _animator);
            states[StateType.MeleeAttackState] = new EnemyAtackState(this, _core, _data, _animator);

            return states;
        }

        protected override void Initialize()
        {
            stateMachine.Initialize(states[StateType.IdleState]);
        }
    }
}
