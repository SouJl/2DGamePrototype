using Root.PixelGame.Game.AI;
using Root.PixelGame.Game.Enemy;
using System;

namespace Root.PixelGame.Game.Core
{
    internal enum EnemyCoreType
    {
        None,
        Stalker,
        Patrol
    }

    internal class EnemyCoreFactory : ICoreFactory<IEnemyCore, EnemyCoreType>
    {
        private readonly IEnemyView _view;
        private readonly IEnemyData _data;
        private readonly IAIFactory aIFactory;

        public EnemyCoreFactory(IEnemyView view, IEnemyData data) 
        {
            _view
              = view ?? throw new ArgumentNullException(nameof(view));

            _data 
                = data ?? throw new ArgumentNullException(nameof(data));

            aIFactory = new AIFactory();
        }

        public IEnemyCore GetCore(EnemyCoreType type)
        { 
            return type switch
            {
                EnemyCoreType.Stalker => CreateStalkerCore(),
                EnemyCoreType.Patrol => CreatePatrolCore(),
                _ => new StubEnemyCore(),

            };
        }
        

  
        private IEnemyCore CreateStalkerCore()
        {
            IPhysicModel physic = new PhysicModel(_view.LObjRigidbody);
            IMove mover = new PhysicsMover(physic, _data);
            IRotate rotator = new SelfRotator(_view.LObjTransform, physic);
            if (_view is StalkerEnemyView stalkerView)
            {
                IAIBehaviour aI = aIFactory.CreateAIBehavior(stalkerView.AIViewComponent);
                return new AIEnemyCore(_view.LObjTransform, _data, mover, rotator, aI);
            }
            else return new StubEnemyCore();
     
        }

        private IEnemyCore CreatePatrolCore()
        {
            IPhysicModel physic = new PhysicModel(_view.LObjRigidbody);
            IMove mover = new PhysicsMover(physic, _data);
            IRotate rotator = new SelfRotator(_view.LObjTransform, physic);
            if (_view is PatrolEnemyView patrolView)
            {
                IAIBehaviour aI = aIFactory.CreateAIBehavior(patrolView.AIViewComponent);
                return new AIEnemyCore(_view.LObjTransform, _data, mover, rotator, aI);
            }
            else return new StubEnemyCore();
        }
    }
}
