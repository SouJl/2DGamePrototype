using System;
using System.Collections.Generic;
using PixelGame.Interfaces;
using PixelGame.Model.Utils;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class CoinsController : IExecute, IDisposable
    {
        private LevelObjectView _playerView;
        private List<LevelObjectView> _coinViews;

        private SpriteAnimatorController _animatorController;

        private ViewService _viewService;

        public CoinsController(LevelObjectView playerView, CoinsView coinsView) 
        {
            _playerView = playerView;
            _playerView.OnLevelObjectContact += OnLevelObjectContact;

            _viewService = new ViewService(coinsView.transform);
            _animatorController = new SpriteAnimatorController(coinsView.AnimationConfig, coinsView.AnimationSpeed);
            _coinViews = new List<LevelObjectView>();
            var coinPrefab = Resources.Load<LevelObjectView>($"SoulItem");

            foreach (var coin in coinsView.CoinsPosition) 
            {
                var coinObj =_viewService.Instantiate<LevelObjectView>(coinPrefab);
                coinObj.Transform.position = coin.position;
                coinObj.Transform.rotation = Quaternion.identity;
                _coinViews.Add(coinObj);
                _animatorController.StartAnimation(coinObj.SpriteRenderer, Enumerators.AnimaState.Idle, true);
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _animatorController.StopAnimation(contactView.SpriteRenderer);
                _viewService.Destroy(contactView);
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
