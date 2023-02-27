using Root.PixelGame.StateMachines;
using System;
using UnityEngine;

namespace Root.PixelGame.Game
{
    internal class PlayerController : BaseController
    {
        private readonly string _dataConfig = @"Player/PlayerData";
        
        private readonly IPlayerView _view;
        private readonly IPlayerData _data;
        private readonly IPlayerCore _core;
        private readonly IStateMachine _playerBehavior;

        private readonly IStateHandler _stateHandler;

        public PlayerController(IPlayerView view) 
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));

            _data = LoadData(_dataConfig);

            _core = new PlayerCore(_view.Transform, _view.Rigidbody, _view.Collider);

            _playerBehavior = new StateMachine();

            _stateHandler = new PlayerStateHandler(_playerBehavior, _core, _data);
        }


        public override void Execute()
        {
            
        }

        public override void FixedExecute()
        {
            
        }

        private IPlayerData LoadData(string path)
        {
            var data = Resources.Load<PlayerData>(path);

            return data;
        }
    }
}
