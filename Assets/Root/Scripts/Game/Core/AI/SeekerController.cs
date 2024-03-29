﻿using Pathfinding;
using PixelGame.Game.AI.Model;
using PixelGame.Tool;
using System;
using UnityEngine;

namespace PixelGame.Game.AI
{
    internal interface ISeeker
    {
        bool IsPathComplete { get; }

        void Init();

        void RecalculatePath();
        void Deinit();
    }
    internal class SeekerController : ISeeker
    {
        private readonly Seeker _seeker;
        private readonly Transform _handler;
        private readonly ITargetSelector _targetSelector;
        private readonly IPathAIModel _model;

        private bool _isPathCompete;

        public bool IsPathComplete => _isPathCompete;

        public SeekerController(
            Seeker seeker, 
            Transform handler, 
            ITargetSelector targetSelector,
            IPathAIModel model)
        {
            _seeker 
                = seeker ?? throw new ArgumentNullException(nameof(seeker));
            _handler
               = handler ?? throw new ArgumentNullException(nameof(handler));
            _targetSelector
               = targetSelector ?? throw new ArgumentNullException(nameof(targetSelector));
            _model 
                = model ?? throw new ArgumentNullException(nameof(model));
        }
        public void Init()
        {
            RecalculatePath();
        }

        public void Deinit()
        {
            _isPathCompete = false;
        }

        public void RecalculatePath()
        {
            if (_targetSelector.CurrentTarget == null) return;

            _isPathCompete = false;

            if (_seeker.IsDone())
            {
                _seeker.StartPath(_handler.position, _targetSelector.CurrentTarget.position, OnPathComplete);
            }
        }

        private void OnPathComplete(Path p)
        {
            if (p.error) return;
            _model.UpdatePath(p);
            _isPathCompete = true;
        }

      
    }
}
