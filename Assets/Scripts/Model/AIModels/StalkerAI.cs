using Pathfinding;
using PixelGame.Configs;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model.AIModels
{
    public class StalkerAI : AbstractAI
    {
        #region private Variables

        private ComponentsModel _components;
        private Seeker _seeker;
        private Transform _target;
        private StalkerAIModel _aIModel;

        private float _updateFrameRate;
        private float _lastTimeUpdate;

        #endregion

        public StalkerAI(AIConfig config, ComponentsModel components,  Seeker seeker, Transform target) : base(config)
        {
            _components = components;
            _seeker = seeker;
            _target = target;
            _aIModel = new StalkerAIModel(Config);

            _updateFrameRate = Config.UpdateFrameRate;
            _lastTimeUpdate = _updateFrameRate;

            Init();
        }

        #region public Methods

        public override void Init()
        {
            RecalculatePath();
        }

        public override void Deint()
        {
            return;
        }

        public override Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            return _aIModel.CalculateVelocity(fromPosition);
        }

        public override void Update(float time)
        {
            if (_lastTimeUpdate > _updateFrameRate)
            {
                RecalculatePath();
                _lastTimeUpdate = 0;
            }
            else
            {
                _lastTimeUpdate += time;
            }
        }

        #endregion

        #region private Methods

        private void RecalculatePath()
        {
            if (_seeker.IsDone())
            {
                _seeker.StartPath(_components.RgdBody.position, _target.position, OnPathComplete);
            }
        }

        private void OnPathComplete(Path p)
        {
            if (p.error) return;
            _aIModel.UpdatePath(p);
        }

        #endregion
    }
}
