using Pathfinding;
using PixelGame.Interfaces;
using PixelGame.Model.AIModels;
using PixelGame.Model.Utils;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model
{
    public class ProtectorEnemyModel : IProtector
    {
        private ComponentsModel _components;
        private IPathfinderAI _pathfinderAI;
        private PatrolAI _patrolAI;
        private Seeker _seeker;
        private Transform _currentTarget;

        private bool _isPatrolling;

        public Transform CurrentTarget { get => _currentTarget; }

        public IPathfinderAI PathfinderAI { get => _pathfinderAI; }
        public ComponentsModel Components { get => _components;  }

        public ProtectorEnemyModel(ComponentsModel components, Seeker seeker, PatrolAI patrolAI, IPathfinderAI pathfinderAI) 
        {
            _components = components;
            _seeker = seeker;
            _patrolAI = patrolAI;
            _pathfinderAI = pathfinderAI;
            _currentTarget = _patrolAI.GetNextTarget();
        }

        public void RecalculatePath() 
        {
            if (Mathf.Abs(Vector2.Distance(_components.Transform.position, _currentTarget.position)) <= 0.2f)
            {
                _currentTarget = _isPatrolling
                   ? _patrolAI.GetNextTarget()
                   : _patrolAI.GetClosestTarget(_components.Transform.position);
            }

            if (_seeker.IsDone()) 
            {
               
                _seeker.StartPath(_components.RgdBody.position, _currentTarget.position, _pathfinderAI.OnPathComplete);
            }
        }

        public void FinishProtection(LevelObjectView invader)
        {
            _isPatrolling = false;
            _currentTarget = invader.Transform;
            RecalculatePath();
        }

        public void StartProtection(LevelObjectView invader)
        {
            _isPatrolling = true;
            _currentTarget = _patrolAI.GetClosestTarget(_components.Transform.position);
            RecalculatePath();
        }

        public Vector2 CalculatePath() 
        {
            return _pathfinderAI.CalculatePath(_components.Transform.position);
        }
    }
}
