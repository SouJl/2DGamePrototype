using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Core.Health;
using Root.PixelGame.Game.Items;
using Root.PixelGame.Game.UI;
using Root.PixelGame.Game.Weapon;
using Root.PixelGame.StateMachines;
using Root.PixelGame.Tool;
using System;
using UnityEngine;

namespace Root.PixelGame.Game
{
    internal interface IPlayerController
    {
        void OnLevelContact(Collider2D collider);

        void TakeDamage(float amount);
        void AddPoints(int amount);
     
    }

    internal class PlayerController : BaseController, IPlayerController
    {
        private readonly string _dataConfig = @"Player/PlayerData";
        
        private readonly IPlayerView _view;
        private readonly IAnimatorController _animator;
        private readonly IWeapon _weapon;

        private readonly IPlayerData _data;
        private readonly IPlayerCore _core;

        private readonly IStateHandler _stateHandler;
        private readonly IHealthController _healthController;
        private readonly ICoinsController _coinsController;

        public PlayerController(
            IPlayerView view,
            IAnimatorController animator,
            IWeapon weapon,
            IGameElementUI<IHealth> healthUI,
            ICoinsController coinsController) 
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));
            _animator 
                = animator ?? throw new ArgumentNullException(nameof(animator));
            _weapon 
                = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _coinsController
                = coinsController ?? throw new ArgumentNullException(nameof(coinsController));

            _data = LoadData(_dataConfig);
            _core = CreatePlayerCore(_view);

            _stateHandler 
                = new PlayerStatesHandler(_data, _core, _animator, weapon); 
            _healthController 
                = new HealthController(healthUI, _data.Health);
            
            _stateHandler.Init();

            _view.Init(this);
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

        public void OnLevelContact(Collider2D collider)
        {
            if (collider.gameObject.tag == "Coin")
            {
                AddPoints(1);
                var coin = collider.GetComponent<CoinView>();
                _coinsController.CoinObtained(coin);
            }
        }

        public void TakeDamage(float amount)
        {
            _healthController.HealthModel.DecreaseHealth(amount);
            _stateHandler.ChangeState(StateType.TakeDamage);
        }

        public void AddPoints(int amount)
        {
            _coinsController.CoinsModel.Increase(amount);
        }

        private IPlayerData LoadData(string path) 
            => ResourceLoader.LoadObject<PlayerData>(path);

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
