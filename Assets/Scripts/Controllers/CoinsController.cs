using System;
using System.Collections.Generic;
using PixelGame.Interfaces;
using PixelGame.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PixelGame.Controllers
{
    public class CoinsController : IExecute, IDisposable
    {
        private LevelObjectView _playerView;
        private List<LevelObjectView> _coinViews;

        private SpriteAnimatorController _animatorController;

        public CoinsController(LevelObjectView playerView, CoinsView coinsView) 
        {
            _playerView = playerView;
            _coinViews = coinsView.LevelCoins;
            _playerView.OnLevelObjectContact += OnLevelObjectContact;

            _animatorController = new SpriteAnimatorController(coinsView.AnimationConfig, coinsView.AnimationSpeed);

            foreach (var coinView in _coinViews) 
            {
                _animatorController.StartAnimation(coinView.SpriteRenderer, Enumerators.AnimaState.Idle, true);
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _animatorController.StopAnimation(contactView.SpriteRenderer);
                contactView.gameObject.SetActive(false);
            }
        }


        public void Execute() { }

        public void FixedExecute()
        {
            _animatorController.Update();
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
            _coinViews.Clear();
        }
    }
}
