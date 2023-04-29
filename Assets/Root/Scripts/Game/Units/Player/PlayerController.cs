using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Game.Core.Health;
using PixelGame.Game.Items;
using PixelGame.Game.UI;
using PixelGame.Game.Weapon;
using PixelGame.Game.StateMachines;
using PixelGame.Tool;
using System;
using UnityEngine;
using PixelGame.Tool.Audio;

namespace PixelGame.Game
{
    internal interface IPlayerController : IDamageable, IKnockbackable
    {
        void OnLevelContact(Collider2D collider);

        void AddPoints(int amount);
    }

    internal class PlayerController : BaseController, IPlayerController
    {
        private readonly string _dataConfig = @"Configs/Player/PlayerData";
        
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

        public void Damage(float amount)
        {
            _healthController.HealthModel.DecreaseHealth(amount);
            AudioManager.Instance.PlaySFX(SFXAudioType.Player, "PlayerHit");
            _stateHandler.ChangeState(StateType.TakeDamage);
        }

        public void Knockback(Vector2 angle, float strength, int direction) 
            => _core.Physic.SetVelocity(strength, angle, direction);
    }
}
