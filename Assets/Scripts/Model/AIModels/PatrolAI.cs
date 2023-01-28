using Pathfinding;
using PixelGame.Configs;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model.AIModels
{
    public class PatrolAI : AbstractAI
    {
        #region private Variables

        private ComponentsModel _components;
        private Seeker _seeker;

        private PatrolAIModel _patrolModel;

        private Transform _target;

        private float _updateFrameRate;
        private float _lastTimeUpdate;
        private bool _isPathComple;

        #endregion

        public PatrolAI(AIConfig config, ComponentsModel components, Seeker seeker) : base(config)
        {
            _components = components;
            _seeker = seeker;

            _patrolModel = new PatrolAIModel(config.waypoints, config.MinSqrDistance);

            _updateFrameRate = Config.UpdateFrameRate;
            _lastTimeUpdate = _updateFrameRate;
            _isPathComple = false;
        }

        #region public Methods

        public override void Init()
        {
            _patrolModel.OnReachedEndOfPath += OnReachedEnd;
            _target = _patrolModel.GetClosestTarget(_components.RgdBody.position);
            RecalculatePath();
        }

        public override void Deint()
        {
            _patrolModel.OnReachedEndOfPath -= OnReachedEnd;
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

        public override Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            return _patrolModel.CalculateVelocity(fromPosition);
        }

        #endregion

        #region private Methods

        private void RecalculatePath()
        {
            _isPathComple = false;

            if (_seeker.IsDone())
            {
                _seeker.StartPath(_components.RgdBody.position, _target.position, OnPathComplete);
            }
        }

        private void OnPathComplete(Path p)
        {
            if (p.error) return;
            _patrolModel.UpdatePath(p);
            _isPathComple = true;
        }

        private void OnReachedEnd()
        {
            if (_isPathComple)
            {
                _target = _patrolModel.GetNextTarget();
                _isPathComple = false;
            }
        }

        #endregion
    }
}
