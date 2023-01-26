using PixelGame.Interfaces;
using PixelGame.Model.AIModels;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model.Utils
{
    public class ProtectorModel : IProtector
    {
        private PatrolModel _patrolModel;

        private ComponentsModel _components;      
        private Transform _currentTarget;
        private bool _isPatrolling;

        public ComponentsModel Components { get => _components; }
        public Transform CurrentTarget { get => _currentTarget; }

        public ProtectorModel(ComponentsModel components, PatrolModel patrol) 
        {
            _components = components;
            _patrolModel = patrol;
            _isPatrolling = true;
            _currentTarget = _patrolModel.GetNextTarget();
        }

        public void OnTargetReached()
        {
            _currentTarget = _isPatrolling
                ? _patrolModel.GetNextTarget()
                : _patrolModel.GetClosestTarget(_components.RgdBody.position);
        }

        public void FinishProtection(LevelObjectView invader)
        {
            if (invader.gameObject.tag != "Player") return;
            _isPatrolling = true;
            _currentTarget = _patrolModel.GetClosestTarget(_components.RgdBody.position);
        }

        public void StartProtection(LevelObjectView invader)
        {
            if (invader.gameObject.tag != "Player") return;
            _isPatrolling = false;
            _currentTarget = invader.Transform;
        }

    
    }
}
