using System;
using PixelGame.Animation;
using PixelGame.Game;
using System.Collections.Generic;
using PixelGame.Game.Core;
using PixelGame.Game.Weapon;

namespace PixelGame.Game.StateMachines
{
    internal class PlayerStatesHandler : StateHandler
    {
        private readonly IPlayerData _data;
        private readonly IPlayerCore _core;
        private readonly IAnimatorController _animator;
        private readonly IWeapon _weapon;

        public PlayerStatesHandler(
            IPlayerData data,
            IPlayerCore core,
            IAnimatorController animator,
            IWeapon weapon) : base()
        {
            _data
                = data ?? throw new ArgumentNullException(nameof(data));
            _core 
                = core ?? throw new ArgumentNullException(nameof(core));
            _animator
                = animator ?? throw new ArgumentNullException(nameof(animator));
            _weapon 
                = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        protected override void Initialize()
        {
            stateMachine.Initialize(states[StateType.IdleState]);
        }

        protected override IDictionary<StateType, IState> CreateStates()
        {
            var states = new Dictionary<StateType, IState>();

            states[StateType.IdleState] = new PlayerIdleState(this, _core, _data, _animator);
            states[StateType.MoveState] = new PlayerMoveState(this, _core, _data, _animator);
            states[StateType.LandState] = new PlayerLandState(this, _core, _data, _animator);
            states[StateType.InAirState] = new PlayerInAirState(this, _core, _data, _animator);
            states[StateType.JumpState] = new PlayerJumpState(this, _core, _data, _animator);
            states[StateType.FallState] = new PlayerFallState(this, _core, _data, _animator);
            states[StateType.WallSlideState] = new PlayerWallSlideState(this, _core, _data, _animator);
            states[StateType.WallJumpState] = new PlayerWallJumpState(this, _core, _data, _animator);
            states[StateType.WallGrabState] = new PlayerWallGrabState(this, _core, _data, _animator);
            states[StateType.LedgeState] = new PlayerLedgeState(this, _core, _data, _animator);
            states[StateType.ClimbState] = new PlayerClimbState(this, _core, _data, _animator);
            states[StateType.MeleeAttackState] = new PlayerMeleeAttackState(this, _core, _data, _animator, _weapon);
            states[StateType.TakeDamage] = new PlayerHitState(this, _core, _data, _animator);

            return states;
        }   
    }
}
