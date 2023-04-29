using PixelGame.Components.Core;
using PixelGame.Game.AI;
using PixelGame.Game.Enemy;
using PixelGame.Tool;
using System;

namespace PixelGame.Game.Core
{
    internal class EnemyCoreFactory : ICoreFactory<IEnemyCore, ICoreComponent>
    {

        private readonly IEnemyData _data;
        private readonly IAIFactory aIFactory;

        public EnemyCoreFactory(
            IEnemyData data, 
            ITargetSelector targetSelector)
        {
            _data 
                = data ?? throw new ArgumentNullException(nameof(data));

            aIFactory = new AIFactory(targetSelector);
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
            return new AIEnemyCore(coreComponent.Transform, physic, null, mover, rotator, aI);
        }
    }
}
