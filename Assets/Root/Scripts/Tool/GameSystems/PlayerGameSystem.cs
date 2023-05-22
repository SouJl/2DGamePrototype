using PixelGame.Animation;
using PixelGame.Game;
using PixelGame.Game.Items;
using PixelGame.Game.UI;
using PixelGame.Game.Weapon;

namespace PixelGame.Tool
{
    internal class PlayerGameSystem : IGameSystemComponent
    {
        private readonly string _animatinDataPath = @"Configs/Animation/PlayerAnimationDataConfig";

        private readonly PlayerController _playerController;

        public PlayerGameSystem(
            PlayerView view, 
            PlayerUI ui,
            CoinView[] coins)
        {
            var playerAnimator = new SpriteAnimatorController(
                view.SpriteRenderer, 
                LoadAnimationConfig(_animatinDataPath));

            var wepon = new Sword(
                view.Weapon,
                playerAnimator);

            var coinsController = new CoinsController(
                ui.CoinsUI, coins);
            
            _playerController = new PlayerController(
                view, 
                playerAnimator, 
                wepon, 
                ui.HealthUI, 
                coinsController);
        }

        public IExecute GetExecutable() => _playerController;

        public void AddPoints(int amount) => 
            _playerController.AddPoints(amount);

        private IAnimationData LoadAnimationConfig(string path) => 
            ResourceLoader.LoadObject<AnimationDataConfig>(path);
    }
}
