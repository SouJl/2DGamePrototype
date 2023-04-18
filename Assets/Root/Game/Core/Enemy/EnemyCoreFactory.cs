using Root.PixelGame.Components.Core;
using Root.PixelGame.Game.AI;
using Root.PixelGame.Game.Enemy;
using System;

namespace Root.PixelGame.Game.Core
{
    internal class EnemyCoreFactory : ICoreFactory<IEnemyCore, ICoreComponent>
    {

        private readonly IEnemyData _data;
        private readonly IAIFactory aIFactory;

        public EnemyCoreFactory(IEnemyData data) 
        {
            _data 
                = data ?? throw new ArgumentNullException(nameof(data));

            aIFactory = new AIFactory();
        }

        public IEnemyCore GetCore(ICoreComponent coreComponent)
        { 
            return coreComponent switch
            {
                ChaserAICoreComponent
                    => CreateAICore(coreComponent as ChaserAICoreComponent),
                PatrolAICoreComponent 
                    => CreateAICore(coreComponent as PatrolAICoreComponent),
                _ => new StubEnemyCore(),
            };
        }

        private IEnemyCore CreateAICore(IEnemyCoreComponent coreComponent)
        {
            IPhysicModel physic = new PhysicModel(coreComponent.Rigidbody);
            IMove mover = new PhysicsMover(physic, _data);
            IRotate rotator = new ScaleRotator(coreComponent.Transform, physic);
            IAIBehaviour aI = aIFactory.CreateAIBehavior(coreComponent.AIViewComponent);
            return new AIEnemyCore(coreComponent.Transform, mover, rotator, aI);
        }
    }
}
