using Root.PixelGame.Game.AI.Model;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.AI
{
    internal class SeekerAI : BaseAI
    {
        protected readonly ISeeker _seeker;
        protected readonly IAIModel _model;

        private float _lastTimeUpdate;

        public SeekerAI(
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
            _seeker.RecalculatePath();
        }

        public override void Deinit()
        {
            _lastTimeUpdate = default;
        }

        public override Vector2 GetNewVelocity(Vector2 fromPosition) 
            => _model.CalculateVelocity(fromPosition);

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
