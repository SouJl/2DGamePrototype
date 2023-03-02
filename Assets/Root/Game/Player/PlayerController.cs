using Root.PixelGame.Animation;
using Root.PixelGame.StateMachines;
using System;
using UnityEngine;

namespace Root.PixelGame.Game
{
    internal class PlayerController : BaseController
    {
        private readonly string _dataConfig = @"Player/PlayerData";
        
        private readonly IPlayerView _view;
        private readonly IAnimatorController _animator;
        private readonly IPlayerData _data;
        private readonly IPlayerCore _core;
        private readonly IStateMachine _playerBehavior;

        private readonly IStateHandler _stateHandler;

        public PlayerController(
            IPlayerView view,
            IAnimatorController animator) 
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));

            _animator 
                = animator ?? throw new ArgumentNullException(nameof(animator));

            _data = LoadData(_dataConfig);

            _core = new PlayerCore(_view.Transform, _view.Rigidbody, _view.Collider, _view.GroundCheck, _view.GroundLayerMask);

            _playerBehavior = new StateMachine();

            _stateHandler = new PlayerStateHandler(_playerBehavior, _core, _data, _animator);
        }


        public override void Execute()
        {
            _animator.Update();
            _playerBehavior.CurrentState.InputData();
            _playerBehavior.CurrentState.LogicUpdate();
        }

        public override void FixedExecute()
        {
            _playerBehavior.CurrentState.PhysicsUpdate();
        }

        private IPlayerData LoadData(string path)
        {
            var data = Resources.Load<PlayerData>(path);

            return data;
        }
    }
}
