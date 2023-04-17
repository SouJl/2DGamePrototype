using Root.PixelGame.Components.Core;
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
        private readonly IEnemyCoreComponent _view;
        private readonly IEnemyData _data;
        private readonly IAIFactory aIFactory;

        public EnemyCoreFactory(
            IEnemyCoreComponent view, 
            IEnemyData data) 
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
            IPhysicModel physic = new PhysicModel(_view.Rigidbody);
            IMove mover = new PhysicsMover(physic, _data);
            IRotate rotator = new SelfRotator(_view.Transform, physic);
            IAIBehaviour aI = aIFactory.CreateAIBehavior(_view.AIViewComponent);
            return new AIEnemyCore(_view.Transform, mover, rotator, aI);

        }

        private IEnemyCore CreatePatrolCore()
        {
            IPhysicModel physic = new PhysicModel(_view.Rigidbody);
            IMove mover = new PhysicsMover(physic, _data);
            IRotate rotator = new SelfRotator(_view.Transform, physic);
            IAIBehaviour aI = aIFactory.CreateAIBehavior(_view.AIViewComponent);
            return new AIEnemyCore(_view.Transform, mover, rotator, aI);
        }
    }
}
