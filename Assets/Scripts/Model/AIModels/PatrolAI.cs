using Pathfinding;
using PixelGame.Configs;
using PixelGame.Model.Utils;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model.AIModels
{
    public class PatrolAI : AbstractAI
    {
        private ComponentsModel _components;
        private Seeker _seeker;
        private LevelObjectTrigger _patrolZone;
        private string _targetTag;

        private PatrolAIModel _patrolModel;
        private Transform _target;

        private bool _isPatrolling;

        private float _updateFrameRate;
        private float _lastTimeUpdate;

        public PatrolAI(AIConfig config, ComponentsModel components, Seeker seeker, LevelObjectTrigger patrolZone, string targetTag) : base(config)
        {
            _components = components;
            _seeker = seeker;
            _patrolZone = patrolZone;
            _targetTag = targetTag;

            _patrolZone.TriggerEnter += StartProtection;
            _patrolZone.TriggerExit += FinishProtection;

            _patrolModel = new PatrolAIModel(config.waypoints, config.MinSqrDistance);
            _patrolModel.OnReachedEndOfPath += OnReachedEnd;

            _updateFrameRate = Config.UpdateFrameRate;
            _lastTimeUpdate = _updateFrameRate;

            _target = _patrolModel.GetNextTarget();

            _isPatrolling = true;
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

        private void StartProtection(LevelObjectView invader)
        {
            _isPatrolling = false;
            _target = invader.Transform;
            RecalculatePath();
        }

        private void FinishProtection(LevelObjectView invader)
        {
            _isPatrolling = true;
            _target = _patrolModel.GetClosestTarget(_components.RgdBody.position);
            RecalculatePath();
        }


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
            _patrolModel.UpdatePath(p);
        }

        private void OnReachedEnd()
        {
            _target = _isPatrolling 
                ? _patrolModel.GetNextTarget() 
                : _patrolModel.GetClosestTarget(_components.RgdBody.position);
            RecalculatePath();
        }
    }
}
