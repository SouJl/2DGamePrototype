using Pathfinding;
using Root.PixelGame.Game.AI.Model;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.AI
{
    internal class PatrolPathController : ISeeker
    {

        private readonly Seeker _seeker;
        private readonly Transform _handler;
        private readonly ITargetedAIModel _model;

        private bool _isPathCompete;

        public bool IsPathComplete => _isPathCompete;

        public PatrolPathController(
            Seeker seeker,
            Transform handler,
            ITargetedAIModel model)
        {
            _seeker
             = seeker ?? throw new ArgumentNullException(nameof(seeker));
            _handler
               = handler ?? throw new ArgumentNullException(nameof(handler));
            _model
                = model ?? throw new ArgumentNullException(nameof(model));

            _model.OnReachedEnd += OnReachedEnd;
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
            if (_isPathCompete) return;

            if (_seeker.IsDone())
            {
                _seeker.StartPath(_handler.position, _model.Target.CurrentTarget.position, OnPathComplete);
            }
        }

        private void OnPathComplete(Path p)
        {
            if (p.error) return;
            _model.UpdatePath(p);
        }

        private void OnReachedEnd()
        {
            if (!_isPathCompete) 
            {
                _isPathCompete = true;
            }    
        }

    }
}
