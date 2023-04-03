using Pathfinding;
using Root.PixelGame.Game.AI.Model;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.AI
{
    internal interface ISeeker
    {
        bool IsPathComplete { get; }
        void RecalculatePath();
    }
    internal class SeekerController : ISeeker
    {
        private readonly Seeker _seeker;
        private readonly Transform _handler;
        private readonly Transform _target;
        private readonly IPathAIModel _model;

        private bool _isPathCompete;

        public bool IsPathComplete => _isPathCompete;

        public SeekerController(
            Seeker seeker, 
            Transform handler, 
            Transform target, 
            IPathAIModel model)
        {
            _seeker 
                = seeker ?? throw new ArgumentNullException(nameof(seeker));
            _handler
               = handler ?? throw new ArgumentNullException(nameof(handler));
            _target
               = target ?? throw new ArgumentNullException(nameof(target));
            _model 
                = model ?? throw new ArgumentNullException(nameof(model));
        }

        public void RecalculatePath()
        {
            _isPathCompete = false;

            if (_seeker.IsDone())
            {
                _seeker.StartPath(_handler.position, _target.position, OnPathComplete);
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
