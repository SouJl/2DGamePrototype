using PixelGame.View;
using System;
using System.Collections.Generic;

namespace PixelGame.Coins
{
    public interface ICoinsController :IDisposable
    {

    }

    public class CoinsController : ICoinsController
    {

        private readonly ICoinsUI _coinsDataView;
        private readonly LevelObjectView _playerView;
        private readonly List<LevelObjectView> _coinViews;

        public CoinsController(
            ICoinsUI coinsDataView, 
            LevelObjectView playerView,
            List<LevelObjectView> coinsView) 
        {
            _coinsDataView 
                = coinsDataView ?? throw new ArgumentNullException(nameof(coinsDataView));

            _playerView
                = playerView ?? throw new ArgumentNullException(nameof(playerView));

            _coinViews
               = coinsView ?? throw new ArgumentNullException(nameof(coinsView));

            _playerView.OnLevelObjectContact += OnLevelObjectContact;

            _coinsDataView.Init();
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                contactView.SetActive(false);
                AddCoin();
            }
        }

        private void AddCoin() => _coinsDataView.IncreaseCoinsValue(1);


        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
            _coinViews.Clear();
        }
    }
}
