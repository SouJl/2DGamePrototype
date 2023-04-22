using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Weapon;
using Root.PixelGame.StateMachines;
using Root.PixelGame.Tool;
using System;
using System.Collections.Generic;
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

            _core = CreatePlayerCore(_view);

            var weapon = new Sword(_animator);

            _stateHandler = new PlayerStatesHandler(_data, _core, _animator, weapon);
            _stateHandler.Init();
        }

        public override void Execute()
        {
            _animator.Update();
            _stateHandler.Execute();
        }

        public override void FixedExecute()
        {
            _stateHandler.FixedExecute();
        }

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
    }

}
