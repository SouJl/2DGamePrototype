using PixelGame.Game.UI;
using PixelGame.Tool.Audio;
using System;
using System.Collections.Generic;

namespace PixelGame.Game.Items
{
    internal interface ICoinsController
    {
        ICoins CoinsModel { get; }

        void CoinObtained(ICoinView coin);
    }

    internal class CoinsController : ICoinsController
    {
        private readonly IGameElementUI<ICoins> _uiElement;
        private readonly IList<ICoinView> _coinViews;
        private readonly ICoins _coinsModel;

        public CoinsController(IGameElementUI<ICoins> uiElement, IList<ICoinView> coinViews) 
        {
            _uiElement
                   = uiElement ?? throw new ArgumentNullException(nameof(uiElement));
            _coinViews
                   = coinViews ?? throw new ArgumentNullException(nameof(coinViews));

            _coinsModel = new CoinsModel();

            _uiElement.InitUI(_coinsModel);
        }

        public ICoins CoinsModel => _coinsModel;

        public void CoinObtained(ICoinView coin)
        {
            var coinIndex = _coinViews.IndexOf(coin);
            AudioManager.Instance.PlaySFX(SFXAudioType.Game, "CoinPickup");
            _coinViews[coinIndex].SetActive(false);
        }
    }
}
