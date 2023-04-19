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

        public void RecalculatePath()
        {
            if (_model.Target.CurrentTarget == null) return;

            _isPathCompete = false;

            if (_seeker.IsDone())
            {
                _seeker.StartPath(_handler.position, _model.Target.CurrentTarget.position, OnPathComplete);
            }
        }

        private void OnPathComplete(Path p)
        {
            if (p.error) return;
            _model.UpdatePath(p);
            _isPathCompete = true;
        }


        private void OnReachedEnd()
        {
            if (_isPathCompete)
            {
                _model.ChangeTarget();
                _isPathCompete = false;
            }
        }
    }
}
