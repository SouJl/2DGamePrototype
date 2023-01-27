using Pathfinding;
using PixelGame.Configs;
using PixelGame.Model.Utils;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model.AIModels
{
    public class ProtectorAI : AbstractAI
    {
        #region private Variables

        private ComponentsModel _components;
        private Seeker _seeker;
        private LevelObjectTrigger _patrolZone;
        private float _speedMultiplier;
        private string _targetTag;

        private ProtectorAIModel _patrolModel;
        private Transform _target;

        private bool _isPatrolling;
        private bool _isPathComple;

        private float _updateFrameRate;
        private float _lastTimeUpdate;

        #endregion

        public ProtectorAI(AIConfig config, ComponentsModel components, Seeker seeker, LevelObjectTrigger patrolZone, float speedMulti,  string targetTag) : base(config)
        {
            _components = components;
            _seeker = seeker;
            _patrolZone = patrolZone;
            _speedMultiplier = speedMulti;
            _targetTag = targetTag;

            _patrolModel = new ProtectorAIModel(config.waypoints, config.MinSqrDistance);

            _updateFrameRate = Config.UpdateFrameRate;
            _lastTimeUpdate = _updateFrameRate;

            _isPathComple = false;
            _isPatrolling = true;

            Init();
        }

        #region public Methods

        public override void Init()
        {
            _patrolZone.TriggerEnter += StartProtection;
            _patrolZone.TriggerExit += FinishProtection;
            _patrolModel.OnReachedEndOfPath += OnReachedEnd;
            _target = _patrolModel.GetNextTarget();
        }

        public override void Deint()
        {
            _patrolZone.TriggerEnter -= StartProtection;
            _patrolZone.TriggerExit -= FinishProtection;
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
            var calculteVel = _patrolModel.CalculateVelocity(fromPosition);
            if (!_isPatrolling) calculteVel *= _speedMultiplier;
            return calculteVel;
        }

        #endregion

        #region private Methods

        private void StartProtection(LevelObjectView invader)
        {
            if (invader.gameObject.tag != _targetTag) return;

            _isPatrolling = false;
            _target = invader.Transform;
            RecalculatePath();
        }

        private void FinishProtection(LevelObjectView invader)
        {
            if (invader.gameObject.tag != _targetTag) return;

            _isPatrolling = true;
            _target = _patrolModel.GetClosestTarget(_components.RgdBody.position);
            RecalculatePath();
        }


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
                _target = _isPatrolling 
                    ? _patrolModel.GetNextTarget() 
                    : _patrolModel.GetClosestTarget(_components.RgdBody.position);

                _isPathComple = false;
            }
        }

        #endregion
    }
}
