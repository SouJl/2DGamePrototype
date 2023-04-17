

using Root.PixelGame.Game.AI.Model;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.AI
{
    internal class PatrolAI : BaseAI
    {
        protected readonly ISeeker _seeker;
        protected readonly IAIModel _model;

        private float _lastTimeUpdate;

        public PatrolAI(
            IAIConfig config,
            ISeeker seeker,
            IAIModel model) : base(config)
        {
            _seeker
                = seeker ?? throw new ArgumentNullException(nameof(seeker));
            _model
                = model ?? throw new ArgumentNullException(nameof(model));

            _lastTimeUpdate = _config.UpdateFrameRate;

            Init();
        }

        public override void Init()
        {
            _model.InitModel();
            _seeker.RecalculatePath();
        }

        public override void Deinit()
        {
            _model.DeinitModel();
            _lastTimeUpdate = default;
        }

        public override Vector2 GetNewVelocity(Vector2 fromPosition)
        {
            return _model.CalculateVelocity(fromPosition);
        }


        public override void UpdateParameters(float time)
        {
            base.UpdateParameters(time);
            if (_lastTimeUpdate > _config.UpdateFrameRate)
            {
                _seeker.RecalculatePath();
                _lastTimeUpdate = 0;
            }
            else
            {
                _lastTimeUpdate += time;
            }
        }

    }
}
