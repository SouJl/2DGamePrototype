using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.StateMachines;
using Root.PixelGame.Tool;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Root.PixelGame.Game
{
    internal class PlayerController : BaseController, IStateHandler
    {
        private readonly string _dataConfig = @"Player/PlayerData";
        
        private readonly IPlayerView _view;
        private readonly IAnimatorController _animator;
        private readonly IPlayerData _data;
        private readonly IPlayerCore _core;

        private readonly IStateMachine _stateMachine;
        private readonly IDictionary<StateType, IState> _playerStates;

        public PlayerController(
            IPlayerView view,
            IAnimatorController animator) 
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));

            _animator 
                = animator ?? throw new ArgumentNullException(nameof(animator));

            _data = LoadData(_dataConfig);

            _core = CreatePlayerCore(_view);

            _stateMachine = new StateMachine();
            _playerStates = CreateStates(_stateMachine);
            _stateMachine.Initialize(GetState(StateType.IdleState));
        }


        public override void Execute()
        {
            _animator.Update();
            _stateMachine.CurrentState.InputData();
            _stateMachine.CurrentState.LogicUpdate();
        }

        public override void FixedExecute()
        {
            _stateMachine.CurrentState.PhysicsUpdate();
        }

        public IState GetState(StateType stateType) 
            => _playerStates[stateType];

        private IPlayerData LoadData(string path) => 
            ResourceLoader.LoadObject<PlayerData>(path);
        
        private IPlayerCore CreatePlayerCore(IPlayerView view)
        {
            var physicModel = new PhysicModel(view.Rigidbody);
            var slopeAnaliser = new SlopeAnaliserTool(view.Rigidbody, _view.Collider);
            var groundCheck = new GroundCheckModel(view.GroundCheck);
            var wallCheck = new WallCheckModel(view.WallCheck);
            var ledgeCheck = new LedgeCheckModel(view.WallCheck, view.LedgeCheck, _data.StandColliderHeight);
            var core = new PlayerCore(view.Transform, physicModel, slopeAnaliser, groundCheck, wallCheck, ledgeCheck);

            return core;
        }

        private IDictionary<StateType, IState> CreateStates(IStateMachine stateMachine)
        {
            var states = new Dictionary<StateType, IState>();

            states[StateType.IdleState] = new PlayerIdleState(this, stateMachine, _core, _data, _animator);
            states[StateType.RunState] = new PlayerMoveState(this, stateMachine, _core, _data, _animator);
            states[StateType.LandState] = new PlayerLandState(this, stateMachine, _core, _data, _animator);
            states[StateType.InAirState] = new PlayerInAirState(this, stateMachine, _core, _data, _animator);
            states[StateType.JumpState] = new PlayerJumpState(this, stateMachine, _core, _data, _animator);
            states[StateType.FallState] = new PlayerFallState(this, stateMachine, _core, _data, _animator);
            states[StateType.WallSlideState] = new PlayerWallSlideState(this, stateMachine, _core, _data, _animator);
            states[StateType.WallJumpState] = new PlayerWallJumpState(this, stateMachine, _core, _data, _animator);
            states[StateType.WallGrabState] = new PlayerWallGrabState(this, stateMachine, _core, _data, _animator);
            states[StateType.LedgeState] = new PlayerLedgeState(this, stateMachine, _core, _data, _animator);
            states[StateType.ClimbState] = new PlayerClimbState(this, stateMachine, _core, _data, _animator);

            return states;
        }  
    }

}
