using Root.PixelGame.Components.AI;
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
            IAIData data,
            ISeeker seeker,
            IAIModel model) : base(data)
        {
            _seeker
                = seeker ?? throw new ArgumentNullException(nameof(seeker));
            _model
                = model ?? throw new ArgumentNullException(nameof(model));

            _lastTimeUpdate = data.UpdateFrameRate;

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
            if (_lastTimeUpdate > data.UpdateFrameRate)
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
